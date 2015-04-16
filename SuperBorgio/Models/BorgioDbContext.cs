using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SuperBorgio.Models.Mapping;

namespace SuperBorgio.Models
{
    public partial class BorgioDbContext : DbContext
    {
        static BorgioDbContext()
        {
            Database.SetInitializer<BorgioDbContext>(null);
        }

        public BorgioDbContext()
            : base("Name=BorgioDbContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }
    }
}
