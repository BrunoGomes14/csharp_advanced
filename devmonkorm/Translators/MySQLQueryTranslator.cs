using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator : ExpressionVisitor
    {
        private static readonly Dictionary<ExpressionType, string> _logicalOperators;

        private StringBuilder _queryBuilder;
        private List<DMFilter> _filters;

        private Stack<string> _currentParameter;
        private Stack<string> _currentField;

        private readonly Type _entity;

        static MySQLQueryTranslator()
        {
            _logicalOperators = new Dictionary<ExpressionType, string>
            {
                [ExpressionType.Not] = "not",
                [ExpressionType.GreaterThan] = ">",
                [ExpressionType.GreaterThanOrEqual] = ">=",
                [ExpressionType.LessThan] = "<",
                [ExpressionType.LessThanOrEqual] = "<=",
                [ExpressionType.Equal] = "=",
                [ExpressionType.Not] = "not",
                [ExpressionType.AndAlso] = "and",
                [ExpressionType.OrElse] = "or"
            };
        }

        public MySQLQueryTranslator(Type entity)
        {
            _queryBuilder = new StringBuilder();
            _filters = new List<DMFilter>();

            _currentField = new Stack<string>();
            _currentParameter = new Stack<string>();

            _entity = entity;
        }

        public Tuple<string, List<DMFilter>> Translate(Expression expression)
        {
            _filters = new List<DMFilter>();

            Visit(expression);

            var query = _queryBuilder.ToString();
            var param = new List<DMFilter>(_filters);

            _queryBuilder.Clear();
            _filters.Clear();

            return new Tuple<string, List<DMFilter>>(query, param);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            switch (node.Method.Name)
            {
                case nameof(string.StartsWith):
                case nameof(string.EndsWith):
                    // columnN LIKE pattern
                    return LikeFunction(node);
                case nameof(string.Contains):
                    // columnN LIKE pattern
                    // column_name IN (value1, value2, ...)
                    return ContainsFunction(node);
                case nameof(string.Replace):
                    // REPLACE(str, find_string, replace_with)
                    return ReplaceFunction(node);
                case nameof(string.Trim):
                    // Trim (str)
                    return TrimFunction(node);
                 case nameof(string.PadRight):
                    // RPAD(str, int, str)
                    return RPadFunction(node);
                 case nameof(string.PadLeft):
                    // LPAD(str, int, str)
                    return LPadFunction(node);
                case nameof(string.Substring):
                    return SubstringExpression(node);
                case nameof(string.ToLower):
                    return ToLowerFunction(node);
                case nameof(Math.Ceiling):
                    return CeilingFunction(node);
                case nameof(Math.Floor):
                    return FloorFunction(node);
                case nameof(string.ToUpper):
                    return ToUpperFunction(node);
                case nameof(string.IndexOf):
                    return IndexOfFunction(node);
                default:
                    break;
            }

            throw new NotSupportedException($"The method '{node.Method.Name}' is not supported");
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType != ExpressionType.Not)
                throw new NotSupportedException("Only not(\"!\") unary operator is supported!");

            _queryBuilder.Append($"{_logicalOperators[node.NodeType]} ");
            _queryBuilder.Append("(");

            Visit(node.Operand);
            _queryBuilder.Append(")");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.ReflectedType == typeof(DateTime))
            {
                if (node.Member.Name == nameof(DateTime.Day) || node.Member.Name == nameof(DateTime.Month) || node.Member.Name == nameof(DateTime.Year)
                 || node.Member.Name == nameof(DateTime.Hour) || node.Member.Name == nameof(DateTime.Minute) || node.Member.Name == nameof(DateTime.Second))
                {
                    _queryBuilder.Append($"{node.Member.Name.ToUpper()}(");
                    Visit(node.Expression);
                    _queryBuilder.Append(")");

                    return node;
                }
            }
            
            CreateParameter(node);

            if (node.Expression.NodeType == ExpressionType.Constant || node.Expression.NodeType == ExpressionType.MemberAccess)
            {
                _currentField.Push(node.Member.Name);

                if(node.Member.Name == "Length")
                {
                     _queryBuilder.Append("Length ( ");
                     Visit(node.Expression);
                    _queryBuilder.Append(")");
                }
                else
                {
                    Visit(node.Expression);
                }

            }
            else
            {
                var column = AttributeHelper.GetDMColumn(typeof(Produto), node.Member.Name);
                _queryBuilder.Append(column.Item1.FieldName);
            }

            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Coalesce)
            {
                return Coalesce(node);
            }
                
            _queryBuilder.Append("(");
            Visit(node.Left);
            _queryBuilder.Append($" {_logicalOperators[node.NodeType]} ");
            Visit(node.Right);
            _queryBuilder.Append(")");

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (_currentParameter.Count == 0)
                _currentParameter.Push($"V{new Random().Next(1111, 9999).ToString()}");

            var value = GetValue(node.Value);
            var DMFilter = new DMFilter(_currentParameter.Pop(), value);

            _queryBuilder.Append(DMFilter.FieldName);
            _filters.Add(DMFilter);

            return node;
        }

        public Expression VisitConstant(ConstantExpression node, MemberExpression member)
        {
            CreateParameter(member);

            var value = GetValue(node.Value);
            var DMFilter = new DMFilter(_currentParameter.Pop(), value);

            _queryBuilder.Append(DMFilter.FieldName);
            _filters.Add(DMFilter);

            return node;
        }

        /// <summary>
        /// Inicialização do parâmetro
        /// </summary>
        /// <param name="node">MemberExpression</param>
        private void CreateParameter(MemberExpression node)
        {
            if (node.Expression.NodeType == ExpressionType.Parameter)
            {
                var column = AttributeHelper.GetDMColumn(node.Expression.Type, node.Member.Name);
                _currentParameter.Push($"{column.Item1.FieldName}{_filters.Count()}");
            }
        }

        /// <summary>
        /// Obtém o valor do parâmetro
        /// </summary>
        /// <param name="input">valor</param>
        /// <returns>retorna uma string com o valor</returns>
        private object GetValue(object input)
        {
            var type = input.GetType();

            if (type.IsGenericType && type == typeof(List<string>))
            {
                return string.Join(", ", (List<string>)input);
            }
            else if (type.IsClass && type != typeof(string))
            {
                var fieldName = _currentField.Pop();
                var fieldInfo = type.GetField(fieldName);

                object value;

                if (fieldInfo != null)
                    value = fieldInfo.GetValue(input);
                else
                    value = type.GetProperty(fieldName).GetValue(input);

                return GetValue(value);
            }
            else
            {
                return input;
            }
        }
    }
}