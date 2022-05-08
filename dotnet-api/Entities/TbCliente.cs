using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apiwithpomelo.Entities
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        [Key]
        [Column("id_cliente", TypeName = "int(11)")]
        public int IdCliente { get; set; }
        [Column("nm_cliente")]
        [StringLength(255)]
        public string NmCliente { get; set; }
        [Column("ds_email")]
        [StringLength(255)]
        public string DsEmail { get; set; }
        [Column("ds_telefone")]
        [StringLength(255)]
        public string DsTelefone { get; set; }
        [Column("ds_cpf")]
        [StringLength(255)]
        public string DsCpf { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_endereco")]
        [StringLength(255)]
        public string DsEndereco { get; set; }
    }
}
