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
        builder.HasIndex(s => new { s.Code, s.CompanyId }).IsUnique();

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
            .HasOne(s => s.Company)
            .WithMany(c => c.ServicesProvided)
            .HasForeignKey(s => s.CompanyId);
    }
}
