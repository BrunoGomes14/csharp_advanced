using apiwithpomelo.Entities;

namespace apiwithpomelo.Repositories 
{
    internal class ProdutoRepository : Repository<TbProduto>, IProdutoRepository
    {
        public ProdutoRepository(mysql_17753_devmonkContext context) : base(context)
        {
        }
    }
}