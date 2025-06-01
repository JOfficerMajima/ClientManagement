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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasIndex(c => c.INN).IsUnique();
            modelBuilder.Entity<Founder>().HasIndex(f => f.INN).IsUnique();

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Founders)
                .WithOne(f => f.Client)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                if (entry.State == EntityState.Added) entry.Entity.CreatedAt = DateTime.UtcNow;
                if (entry.State != EntityState.Unchanged) entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(ct);
        }
    }
}
