using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função FLOOR
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression FloorFunction(MethodCallExpression node)
        {
            _queryBuilder.Append("FLOOR(");
            Visit(node.Arguments[0]);
            _queryBuilder.Append(")");

            return node;
        }
    }
}