using System;
using devmonkorm.Attributes;

namespace devmonkorm
{
    [DMTable("tb_produto")]
    public class Produto
    {
        [DMKey("id_produto", Required = true, TypeField = "int")]
        public int Id { get; set; }

        [DMColumn("nm_produto", Required = true, TypeField = "varchar(255)")]
        public string Nome { get; set; }

        [DMColumn("ds_produto", TypeField = "varchar(800)")]
        public string Descricao { get; set; }

        [DMColumn("ds_categoria", TypeField = "varchar(255)")]
        public string Categoria { get; set; }

        [DMColumn("vl_preco", TypeField = "decimal(15, 2)")]
        public double Preco { get; set; }
        
        [DMColumn("qtd_estoque", TypeField = "int")]
        public int QtdEstoque { get; set; }

        [DMColumn("vl_avaliacao", TypeField = "decimal(15, 2)")]
        public double Avaliacao { get; set; }

        [DMColumn("dt_inclusao", TypeField = "datetime")]
        public DateTime DataInclusao { get; set; }
    }
}