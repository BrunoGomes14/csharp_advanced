using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apiwithpomelo.Entities
{
    [Table("tb_produto")]
    public partial class TbProduto
    {
        [Key]
        [Column("id_produto", TypeName = "int(11)")]
        public int IdProduto { get; set; }
        [Column("nm_produto")]
        [StringLength(255)]
        public string NmProduto { get; set; }
        [Column("ds_descricao")]
        [StringLength(255)]
        public string DsDescricao { get; set; }
        [Column("vl_preco")]
        [StringLength(255)]
        public string VlPreco { get; set; }
        [Column("ds_categoria")]
        [StringLength(255)]
        public string DsCategoria { get; set; }
        [Column("qtd_estoque")]
        [StringLength(255)]
        public string QtdEstoque { get; set; }
        [Column("vl_avaliacao", TypeName = "decimal(10,2)")]
        public decimal? VlAvaliacao { get; set; }
    }
}
