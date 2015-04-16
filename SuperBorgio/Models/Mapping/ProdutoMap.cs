using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SuperBorgio.Models.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
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
