using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função TRIM
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
    
        private Expression TrimFunction(MethodCallExpression node)
        {
            // TRIM(str)
            _queryBuilder.Append("TRIM(");
            Visit(node.Object);
            _queryBuilder.Append(")");

            return node;
        }
    }
}