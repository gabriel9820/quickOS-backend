using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class ServiceOrderServiceConfiguration : IEntityTypeConfiguration<ServiceOrderService>
{
    public void Configure(EntityTypeBuilder<ServiceOrderService> builder)
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
            .HasOne(s => s.Service)
            .WithMany(s => s.ServiceOrderServices)
            .HasForeignKey(s => s.ServiceId)
            .IsRequired();

        builder
            .HasOne(s => s.ServiceOrder)
            .WithMany(s => s.Services)
            .HasForeignKey(s => s.ServiceOrderId)
            .IsRequired();
    }
}
