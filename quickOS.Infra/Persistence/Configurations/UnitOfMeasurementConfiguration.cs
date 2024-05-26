using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurement>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasurement> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.ExternalId).IsUnique();
        builder.HasIndex(u => u.Abbreviation).IsUnique();

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Abbreviation)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(u => u.IsActive).IsRequired();

        builder
            .HasMany(u => u.Products)
            .WithOne(p => p.UnitOfMeasurement)
            .HasForeignKey(p => p.UnitOfMeasurementId);

    }
}
