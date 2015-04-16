using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBorgio.Dominio.Entidades;

namespace SuperBorgio.Dominio.Configuracao
{
    class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Codigo)
                .HasMaxLength(50);

            this.Property(t => t.Descricao)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Produtos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Custo1).HasColumnName("Custo1");
            this.Property(t => t.Custo2).HasColumnName("Custo2");
            this.Property(t => t.Custo3).HasColumnName("Custo3");
            this.Property(t => t.Custo4).HasColumnName("Custo4");
            this.Property(t => t.Custo5).HasColumnName("Custo5");
        }
    }
}
