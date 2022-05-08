using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função TOLOWER
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression ToLowerFunction(MethodCallExpression node)
        {
            _queryBuilder.Append("LOWER(");
            Visit(node.Object);
            _queryBuilder.Append(")");

            return node;
        }
    }
}