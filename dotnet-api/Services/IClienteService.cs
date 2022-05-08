using System;
using System.Collections.Generic;
using apiwithpomelo.Models;

namespace apiwithpomelo.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Create(Cliente cliente);
        Cliente Update(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        void Delete(int id);
        Cliente Get(int id);
    }
}