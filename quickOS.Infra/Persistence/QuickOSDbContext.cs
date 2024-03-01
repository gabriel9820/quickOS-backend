using System.Reflection;
using Microsoft.EntityFrameworkCore;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence;

public class QuickOSDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    public QuickOSDbContext(DbContextOptions<QuickOSDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            var now = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetCreatedAt(now);
                    entry.Entity.SetUpdatedAt(now);
                    break;
                case EntityState.Modified:
                    entry.Entity.SetUpdatedAt(now);
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
