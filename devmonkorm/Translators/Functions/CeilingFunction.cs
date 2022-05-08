using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função CEILING
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression CeilingFunction(MethodCallExpression node)
        {
            _queryBuilder.Append("CEILING(");
            Visit(node.Arguments[0]);
            _queryBuilder.Append(")");
            return node;
        }
    }
}