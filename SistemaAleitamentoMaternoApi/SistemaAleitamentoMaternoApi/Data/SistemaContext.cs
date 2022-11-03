using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SistemaAleitamentoMaternoApi.Models;
using System.Threading;

namespace SistemaAleitamentoMaternoApi.Data
{
    public class SistemaContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todasEntidades = modelBuilder.Model.GetEntityTypes();
            foreach (var entidade in todasEntidades)
            {
                entidade.AddProperty("CreatedDate", typeof(DateTime));
                entidade.AddProperty("UpdatedDate", typeof(DateTime));
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified);
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                }
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
