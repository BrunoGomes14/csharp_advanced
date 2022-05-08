using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função PADLEFT
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
    
        private Expression LPadFunction(MethodCallExpression node)
        {
            // LPAD(str, int, str)
            _queryBuilder.Append("LPAD(");
            Visit(node.Object);
            _queryBuilder.Append(", "  + ((ConstantExpression)node.Arguments[0]).Value);
            _queryBuilder.Append(", '" + ((ConstantExpression)node.Arguments[1]).Value + "' )");

            return node;
        }
    }
}