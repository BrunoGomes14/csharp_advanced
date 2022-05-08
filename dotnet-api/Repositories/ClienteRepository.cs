using apiwithpomelo.Entities;

namespace apiwithpomelo.Repositories 
{
    internal class ClienteRepository : Repository<TbCliente>, IClienteRepository
    {
        public ClienteRepository(mysql_17753_devmonkContext context) : base(context)
        {
        }
    }
}