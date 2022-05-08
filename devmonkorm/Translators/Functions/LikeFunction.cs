using System.Linq.Expressions;

namespace devmonkorm.Helpers
{
    public partial class MySQLQueryTranslator
    {
        /// <summary>
        /// Tratamento da função LIKE
        /// </summary>
        /// <param name="node">MethodCallExpression</param>
        /// <returns>Expression</returns>
        private Expression LikeFunction(MethodCallExpression node)
        {
            // columnN LIKE pattern
            Visit(node.Object);
            _queryBuilder.Append(" LIKE ");

            if (node.Method.Name == nameof(string.StartsWith))
                Visit(Expression.Constant($"{((ConstantExpression)node.Arguments[0]).Value}%"));
            else
                Visit(Expression.Constant($"%{((ConstantExpression)node.Arguments[0]).Value}"));

            return node;
        }
    }
}