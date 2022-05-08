using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função ToUpper
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression IndexOfFunction(MethodCallExpression node)
        {

            _queryBuilder.Append("LOCATE(");
            
            VisitConstant((ConstantExpression)node.Arguments[0]
                , (MemberExpression)node.Object);

            _queryBuilder.Append(",");
            Visit(node.Object);
            _queryBuilder.Append(")");

            CreateParameter((MemberExpression)node.Object);

            return node;
        }
    }
}