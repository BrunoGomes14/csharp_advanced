using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função PADRIGHT
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
    
        private Expression RPadFunction(MethodCallExpression node)
        {
            // RPAD(str, int, str)
            _queryBuilder.Append("RPAD(");
            Visit(node.Object);
            _queryBuilder.Append(", "  + ((ConstantExpression)node.Arguments[0]).Value);
            _queryBuilder.Append(", '" + ((ConstantExpression)node.Arguments[1]).Value + "' )");

            return node;
        }
    }
}