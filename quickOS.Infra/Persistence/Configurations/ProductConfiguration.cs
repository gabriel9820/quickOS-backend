using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.ExternalId).IsUnique();
        builder.HasIndex(p => new { p.Code, p.TenantId }).IsUnique();

        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.UpdatedAt).IsRequired();

        builder.Property(p => p.Code).IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(p => p.CostPrice)
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(p => p.ProfitMargin)
            .HasPrecision(10, 2)
            .IsRequired(false);

        builder.Property(p => p.SellingPrice)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.Stock)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.IsActive).IsRequired();

        builder
            .HasOne(p => p.Tenant)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.TenantId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(p => p.UnitOfMeasurement)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UnitOfMeasurementId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(p => p.ServiceOrderProducts)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId);
    }
}
