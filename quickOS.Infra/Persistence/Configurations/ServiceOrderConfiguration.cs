using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.ExternalId).IsUnique();
        builder.HasIndex(s => new { s.Number, s.TenantId }).IsUnique();

        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt).IsRequired();

        builder.Property(s => s.Number).IsRequired();

        builder.Property(s => s.Date).IsRequired();

        builder.Property(s => s.Status).IsRequired();

        builder.Property(s => s.EquipmentDescription)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(s => s.ProblemDescription)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(s => s.TechnicalReport)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(s => s.TotalPrice).HasPrecision(10, 2).IsRequired();

        builder
            .HasOne(s => s.Tenant)
            .WithMany(t => t.ServiceOrders)
            .HasForeignKey(s => s.TenantId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(s => s.Customer)
            .WithMany(c => c.ServiceOrders)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(s => s.Technician)
            .WithMany(t => t.ServiceOrders)
            .HasForeignKey(s => s.TechnicianId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(s => s.Products)
            .WithOne(p => p.ServiceOrder)
            .HasForeignKey(p => p.ServiceOrderId);

        builder
            .HasMany(s => s.Services)
            .WithOne(s => s.ServiceOrder)
            .HasForeignKey(s => s.ServiceOrderId);
    }
}
