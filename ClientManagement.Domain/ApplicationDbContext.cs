using ClientManagement.Domain.Entities;
using ClientManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Founder> Founders { get; set; }

        public DbSet<FounderClient> FounderClients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasIndex(c => c.INN).IsUnique();
            modelBuilder.Entity<Founder>().HasIndex(f => f.INN).IsUnique();

            modelBuilder.Entity<FounderClient>().HasKey(f => new { f.ClientId, f.FounderId });
            modelBuilder.Entity<FounderClient>().HasOne(f => f.Client).WithMany(c => c.FounderClients).HasForeignKey(f => f.ClientId);
            modelBuilder.Entity<FounderClient>().HasOne(f => f.Founder).WithMany(c => c.FounderClients).HasForeignKey(f => f.FounderId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                if (entry.Entity is AuditedEntity auditedEntity)
                {
                    if (entry.State == EntityState.Added) auditedEntity.CreatedAt = DateTime.UtcNow;
                    if (entry.State != EntityState.Unchanged) auditedEntity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(ct);
        }
    }
}
