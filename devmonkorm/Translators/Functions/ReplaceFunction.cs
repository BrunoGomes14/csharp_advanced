using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função REPLACE
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression ReplaceFunction(MethodCallExpression node)
        {
            // REPLACE(str, find_string, replace_with)
            _queryBuilder.Append("REPLACE(");
            Visit(node.Object);
            _queryBuilder.Append(", ");
            Visit(node.Arguments[0]);
            _queryBuilder.Append(", ");
            Visit(node.Arguments[1]);
            _queryBuilder.Append(")");

            return node;
        }
    }
}