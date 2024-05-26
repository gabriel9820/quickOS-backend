using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.ExternalId).IsUnique();

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.IsActive).IsRequired();

        builder
            .HasMany(t => t.Users)
            .WithOne(u => u.Tenant)
            .HasForeignKey(u => u.TenantId);

        builder
            .HasMany(t => t.ServicesProvided)
            .WithOne(s => s.Tenant)
            .HasForeignKey(s => s.TenantId);

        builder
            .HasMany(t => t.Products)
            .WithOne(p => p.Tenant)
            .HasForeignKey(p => p.TenantId);

        builder
            .HasMany(t => t.Customers)
            .WithOne(c => c.Tenant)
            .HasForeignKey(c => c.TenantId);

        builder
            .HasMany(t => t.ServiceOrders)
            .WithOne(s => s.Tenant)
            .HasForeignKey(s => s.TenantId);
    }
}
