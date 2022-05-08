using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator 
    {
        private Expression Coalesce(BinaryExpression node)
        {
            _queryBuilder.Append("IFNULL(");
            Visit(node.Left);
            _queryBuilder.Append(",");
            Visit(node.Right);
            _queryBuilder.Append(")");

            return node;
        }
    }
}