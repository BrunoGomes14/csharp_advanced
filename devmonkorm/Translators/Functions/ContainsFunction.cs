using System;
using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função CONTAINS
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression ContainsFunction(MethodCallExpression node)
        {
            // ExpressionType.Parameter: x.Descricao.Contains("a")
            // ExpressionType.Constant: new List<string> { "Tom", "Adam", "Paul" }.Contains(x.Descricao)
            if (((MemberExpression)node.Object).Expression.NodeType == ExpressionType.Parameter)
            {
                // columnN LIKE pattern
                Visit(node.Object);
                _queryBuilder.Append(" LIKE ");
                Visit(Expression.Constant($"%{((ConstantExpression)node.Arguments[0]).Value}%"));
            }
            else if (((MemberExpression)node.Object).Expression.NodeType == ExpressionType.Constant)
            {
                // column_name IN (value1, value2, ...)
                Visit(node.Arguments[0]);
                _queryBuilder.Append(" IN (");
                Visit(node.Object);
                _queryBuilder.Append(")");
            }
            else
            {
                throw new NotSupportedException(string.Format("The method '{0}' is not supported", node.Method.Name));
            }

            return node;
        }
    }
}