using System.Reflection;
using Microsoft.EntityFrameworkCore;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence;

public class QuickOSDbContext : DbContext
{
    private readonly IRequestProvider _requestProvider;

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<ServiceOrderProduct> ServiceOrdersProducts { get; set; }
    public DbSet<ServiceOrderService> ServiceOrdersServices { get; set; }
    public DbSet<ServiceProvided> ServicesProvided { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AccountPayable> AccountsPayable { get; set; }
    public DbSet<AccountReceivable> AccountsReceivable { get; set; }

    public QuickOSDbContext(DbContextOptions<QuickOSDbContext> options, IRequestProvider requestProvider) : base(options)
    {
        _requestProvider = requestProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Customer>().HasQueryFilter(c => c.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<Product>().HasQueryFilter(p => p.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<ServiceOrder>().HasQueryFilter(s => s.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<ServiceOrderProduct>().HasQueryFilter(s => s.ServiceOrder.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<ServiceOrderService>().HasQueryFilter(s => s.ServiceOrder.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<ServiceProvided>().HasQueryFilter(s => s.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<User>().HasQueryFilter(u => u.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<AccountPayable>().HasQueryFilter(a => a.TenantId == _requestProvider.TenantId);
        modelBuilder.Entity<AccountReceivable>().HasQueryFilter(a => a.TenantId == _requestProvider.TenantId);

        modelBuilder.Seed();
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
                    entry.Entity.SetTenantId(_requestProvider.TenantId);
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
