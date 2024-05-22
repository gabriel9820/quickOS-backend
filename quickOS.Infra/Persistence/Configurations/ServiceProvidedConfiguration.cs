using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class ServiceProvidedConfiguration : IEntityTypeConfiguration<ServiceProvided>
{
    public void Configure(EntityTypeBuilder<ServiceProvided> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.ExternalId).IsUnique();
        builder.HasIndex(s => new { s.Code, s.TenantId }).IsUnique();

        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt).IsRequired();

        builder.Property(s => s.Code).IsRequired();

        builder.Property(s => s.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Description).HasMaxLength(1000).IsRequired(false);

        builder.Property(s => s.Price).HasPrecision(10, 2).IsRequired();

        builder.Property(s => s.IsActive).IsRequired();

        builder
            .HasOne(s => s.Tenant)
            .WithMany(t => t.ServicesProvided)
            .HasForeignKey(s => s.TenantId)
            .IsRequired();

        builder
            .HasMany(t => t.ServiceOrderServices)
            .WithOne(s => s.Service)
            .HasForeignKey(s => s.ServiceId);
    }
}
