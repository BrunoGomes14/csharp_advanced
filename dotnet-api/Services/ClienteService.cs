using System;
using System.Collections.Generic;
using System.Linq;
using apiwithpomelo.Entities;
using apiwithpomelo.Models;
using apiwithpomelo.Repositories;

namespace apiwithpomelo.Services
{
    public class ClienteService : IClienteService, IDisposable
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public Cliente Create(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                throw new ArgumentException("O nome do cliente é obrigatório.");
            if (string.IsNullOrEmpty(cliente.CPF))
                throw new ArgumentException("O CPF do cliente é obrigatório.");

            cliente.Id = 0;

            TbCliente entity = cliente;

            _repo.Add(entity);
            _repo.Commit();

            cliente.Id = entity.IdCliente;
            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            if (cliente.Id <= 0)
                throw new ArgumentException("A identificação do cliente é obrigatória.");
            if (string.IsNullOrEmpty(cliente.Nome))
                throw new ArgumentException("O nome do cliente é obrigatório.");
            if (string.IsNullOrEmpty(cliente.CPF))
                throw new ArgumentException("O CPF do cliente é obrigatório.");

            _repo.Update(cliente);
            return cliente;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _repo.GetAll().Select(s => (Cliente)s);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("A identificação do cliente é obrigatória.");

            var entity = _repo.Get(id);

            if (entity == null || entity.IdCliente <= 0)
                throw new ArgumentException("Cliente não encontrado.");

            _repo.Delete(entity);
        }

        public Cliente Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("A identificação do cliente é obrigatória.");

            var entity = _repo.Get(id);

            if (entity == null || entity.IdCliente <= 0)
                throw new ArgumentException("Cliente não encontrado.");

            return entity;
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}