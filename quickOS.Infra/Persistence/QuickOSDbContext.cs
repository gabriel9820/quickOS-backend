using System.Reflection;
using Microsoft.EntityFrameworkCore;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence;

public class QuickOSDbContext : DbContext
{
    private IRequestProvider _requestProvider;

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<ServiceProvided> ServicesProvided { get; set; }

    public QuickOSDbContext(DbContextOptions<QuickOSDbContext> options, IRequestProvider requestProvider) : base(options)
    {
        _requestProvider = requestProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ServiceProvided>().HasQueryFilter(s => s.CompanyId == _requestProvider.CompanyId);

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

        foreach (var entry in ChangeTracker.Entries<MultiTenantEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetTenantId(_requestProvider.CompanyId);
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
