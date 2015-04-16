using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using SuperBorgio.Dominio.Configuracao;
using SuperBorgio.Dominio.Entidades;
using SuperBorgio.Dominio.Repositorio;

namespace SuperBorgio.Dominio.Contexto
{
    public class DbContexto : DbContext, IUnitOfWork
    {

        public DbContexto()
            : base("DbContexto")
        {

          //    Database.SetInitializer(new PreparaDbcontexto());


        }



        // Corretora
        public DbSet<TabelaAuxiliar> TabelasAuxiliares { get; set; }
       


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            modelBuilder.Configurations.Add(new ProdutoConfiguracao());




        }
       

        public int Commit()
        {
            try
            {
                return SaveChanges();
            }
            catch (Exception erro)
            {

                throw new EntityException("Falha banco de dados: " + erro.Message);
            }
        }

        public Task CommitAsync()
        {
            return SaveChangesAsync();
        }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }


    }
}
