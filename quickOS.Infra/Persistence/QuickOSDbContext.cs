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
    }
}
