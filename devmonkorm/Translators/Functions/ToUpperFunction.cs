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
        private Expression ToUpperFunction(MethodCallExpression node)
        {
            _queryBuilder.Append("UPPER(");
            Visit(node.Object);
            _queryBuilder.Append(")");

            return node;
        }
    }
}