using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiwithpomelo.Entities
{
    public partial class mysql_17753_devmonkContext : DbContext
    {
        public mysql_17753_devmonkContext()
        {
        }

        public mysql_17753_devmonkContext(DbContextOptions<mysql_17753_devmonkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbClientes { get; set; }
        public virtual DbSet<TbProduto> TbProdutos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
