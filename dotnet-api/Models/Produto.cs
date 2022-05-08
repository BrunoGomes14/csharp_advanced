using System;
using apiwithpomelo.Entities;

namespace apiwithpomelo.Models
{
    public class Produto 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public decimal? Avaliacao { get; set; }

        public static implicit operator TbProduto(Produto produto)
        {
            return new TbProduto()
            {
                IdProduto = produto.Id,
                DsCategoria = produto.Categoria,
                DsDescricao = produto.Descricao,
                NmProduto = produto.Nome,
                QtdEstoque = produto.QuantidadeEstoque.ToString(),
                VlAvaliacao = produto.Avaliacao,
                VlPreco = produto.Preco.ToString()                
            };
        }

        public static implicit operator Produto(TbProduto produto)
        {
            decimal.TryParse(produto.VlPreco, out var preco);
            decimal.TryParse(produto.QtdEstoque, out var quantidadeEstoque);

            return new Produto()
            {
                Avaliacao = produto.VlAvaliacao,
                Categoria = produto.DsCategoria,
                Descricao = produto.DsDescricao,
                Id = produto.IdProduto,
                Nome = produto.NmProduto,
                Preco = preco,
                QuantidadeEstoque = quantidadeEstoque
            };;
        }
    }
}