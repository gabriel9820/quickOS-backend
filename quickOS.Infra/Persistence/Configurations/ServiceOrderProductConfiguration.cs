using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class ServiceOrderProductConfiguration : IEntityTypeConfiguration<ServiceOrderProduct>
{
    public void Configure(EntityTypeBuilder<ServiceOrderProduct> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.ExternalId).IsUnique();
        builder.HasIndex(s => new { s.Item, s.ServiceOrderId }).IsUnique();

        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt).IsRequired();

        builder.Property(s => s.Item).IsRequired();

        builder.Property(s => s.Quantity).HasPrecision(6, 2).IsRequired();

        builder.Property(s => s.Price).HasPrecision(10, 2).IsRequired();

        builder.Property(s => s.TotalPrice).HasPrecision(10, 2).IsRequired();

        builder
            .HasOne(s => s.Product)
            .WithMany(s => s.ServiceOrderProducts)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(s => s.ServiceOrder)
            .WithMany(s => s.Products)
            .HasForeignKey(s => s.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
