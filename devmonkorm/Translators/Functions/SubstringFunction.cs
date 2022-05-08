using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        
        /// <summary>
        /// Tratamento da função SUBSTRING
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression SubstringExpression(MethodCallExpression node)
        {
            
            _queryBuilder.Append("SUBSTRING(");
            Visit(node.Object);
            _queryBuilder.Append(", ");
            _queryBuilder.Append(node.Arguments[0]);

            if (node.Arguments.Count == 1)
            {
                _queryBuilder.Append(" + 1");
                _queryBuilder.Append(", LENGTH(");
                Visit(node.Object);
                _queryBuilder.Append("))");
            }
            else
            {
                _queryBuilder.Append(", ");
                _queryBuilder.Append(node.Arguments[1]);
                _queryBuilder.Append(")");
            }

            return node;
        }

    
    }
}