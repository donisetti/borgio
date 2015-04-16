using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Configuracao;
using BorgioBase.Dominio1.Entidades;
using BorgioBase.Dominio1.Repositorio;

namespace BorgioBase.Dominio1.Contexto
{
    public class DbContexto : DbContext, IUnitOfWork
    {

        public DbContexto()
            : base("DbContexto")
        {

            Database.SetInitializer(new PreparaDbcontexto());


        }



        // Corretora
        public DbSet<TabelaAuxiliar> TabelasAuxiliares { get; set; }
        //public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Colaborador> Colaboradores { get; set; }
        //public DbSet<Operadora> Operadoras { get; set; }
        //public DbSet<PlanoSaude> PlanosSaudes { get; set; }

        //public DbSet<PessoaFisica> Clientes { get; set; }
        //public DbSet<Titular> Titulares { get; set; }
        //public DbSet<Dependente> Dependentes { get; set; }
        //public DbSet<PessoaJuridica> Empresas { get; set; }
        //public DbSet<Proposta> Propostas { get; set; }

        //public DbSet<Ocorrencia> Ocorrencias { get; set; }

        //public DbSet<Visita> Visitas { get; set; }
        //public DbSet<Mensalidade> Mensalidades { get; set; }

        //public DbSet<Baixa> Baixas { get; set; }
        //public DbSet<Comissao> Comissoes { get; set; }







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




        }

        /*
                     Mapeamento 1-1

            Cliente->Endereço


              modelBuilder.Entity<Cliente>()
                            .HasRequired(c => c.Endereco)
                            .WithRequiredPrincipal(e => e.Cliente);

            Mapeamento m-n

              modelBuilder.Entity<Revista>().HasMany(r => r.Movimentacoes)
                            .WithMany(m => m.Revistas)
                            .Map(m =>
                                     {
                                         m.MapLeftKey("sRevistaID");
                                         m.MapRightKey("sMovimentacaoID");
                                         m.ToTable("tbMovimentacaoRevista");
                                     });
         */

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
