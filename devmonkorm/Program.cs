using System;
using System.Linq;
using devmonkorm.Common;

namespace devmonkorm
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DMContextOptions("server=my01.winhost.com;user id=devmonk;password=devmonk;database=mysql_17753_devmonk");
            var context = new MerceariaDMContext(options.UseMySql());
            
            var p = new Produto () { Id = 8, Nome = "Notebook", Categoria = "PC", Preco = 19.50 };

            //context.Produtos.Update(p);

            //context.Produtos.Where(w => w.Descricao.ToLower() == "au");

            var prod = new Produto() {
                Nome = "Teste 1234",
                Descricao = "Mouse que brilha",
                Preco = 49.99,
                Categoria = "Mouse",
                QtdEstoque = 13,
                Avaliacao = 11,
                DataInclusao = DateTime.Now
            };

            //context.Produtos.Add(prod);

            // var produtos = context.Produtos
            //     .Where(w => w.Id > 10)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Preco < 2000)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.StartsWith("A"))
            //     .ToList();
            
            // var produtos = context.Produtos
            //     .Where(w => Math.Ceiling(w.Preco) == 50
            //         && Math.Floor(w.Preco) == 49)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Contains("top"))
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.IndexOf("u") == 2)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.PadLeft(20, 'A') == "AAAAAAAAbacate verde")
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.PadRight(20, 'e') == "Abacate verdeeeeeeee")
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Replace("e", "a") == "Abacata varda")
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Substring(8) == "verde")
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Trim() == "Mouse que brilha")
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Length == 13)
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.DataInclusao.Day == 8 && w.DataInclusao.Month == 12)
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.DataInclusao.Month == 12)
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => (w.Descricao ?? "Nulo") == "Nulo")
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.ToUpper() == "ABACATE VERDE")
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.ToUpper().StartsWith("A"))
            //     .OrderBy(o => o.Id)
            //     .ToList();


            // ERRO
            // var produtos = context.Produtos
            //     .Where(w => w.Descricao.Replace("e", "a").Contains("Abacata"))
            //     .OrderBy(o => o.Id)
            //     .ToList();

            // foreach (var item in context.Produtos.Where(w => w.Id > 14))
            // {
            //     Console.WriteLine($"{item.Id} - {item.Descricao} | {item.Preco.ToString("C2")} |");
            // }

            var produtos = context.Produtos
                .Where(w => w.Id > 14)
                .OrderBy(o => o.Id)
                .ToList();

            foreach (var item in produtos)
            {
                Console.WriteLine($"{item.Id} - {item.Descricao} | {item.Preco.ToString("C2")} |");
            }
        }
    }
}