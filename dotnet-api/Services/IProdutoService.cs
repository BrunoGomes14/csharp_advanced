using System.Collections.Generic;
using apiwithpomelo.Models;

namespace apiwithpomelo.Services
{
    public interface IProdutoService
    {
        Produto Create(Produto cliente);
        Produto Update(Produto cliente);
        IEnumerable<Produto> GetAll();
        void Delete(int id);
        Produto Get(int id);
    }
}