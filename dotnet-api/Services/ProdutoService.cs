using System;
using System.Collections.Generic;
using System.Linq;
using apiwithpomelo.Entities;
using apiwithpomelo.Models;
using apiwithpomelo.Repositories;

namespace apiwithpomelo.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public Produto Create(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
                throw new ArgumentException("O nome do produto é obrigatório.");
            if (produto.Preco <= 0)
                throw new ArgumentException("O preço do produto é obrigatório.");

            produto.Id = 0;

            TbProduto entity = produto;
            _repo.Add(entity);

            produto.Id = entity.IdProduto;
            return produto;
        }

        public Produto Update(Produto produto)
        {
            if (produto.Id <= 0)
                throw new ArgumentException("A identificação do produto é obrigatória.");
            if (string.IsNullOrEmpty(produto.Nome))
                throw new ArgumentException("O nome do produto é obrigatório.");
            if (produto.Preco <= 0)
                throw new ArgumentException("O preço do produto é obrigatório.");

            _repo.Update(produto);
            return produto;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _repo.GetAll().Select(s => (Produto)s);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("A identificação do produto é obrigatória.");

            var entity = _repo.Get(id);

            if (entity == null || entity.IdProduto <= 0)
                throw new ArgumentException("Produto não encontrado.");

            _repo.Delete(entity);
        }

        public Produto Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("A identificação do produto é obrigatória.");

            var entity = _repo.Get(id);

            if (entity == null || entity.IdProduto <= 0)
                throw new ArgumentException("Produto não encontrado.");

            return entity;
        }
    }
}