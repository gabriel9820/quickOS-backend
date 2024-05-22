using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.ExternalId).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.CellPhone).IsUnique();
        builder.HasIndex(u => u.RefreshToken).IsUnique();

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.Property(u => u.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.CellPhone)
            .HasMaxLength(15)
            .IsFixedLength()
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Password).IsRequired();

        builder.Property(u => u.IsActive).IsRequired();

        builder.Property(u => u.Role).IsRequired();

        builder.OwnsOne(u => u.Address)
            .Property(a => a.ZipCode)
            .HasMaxLength(9)
            .IsFixedLength()
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.Street)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.Number)
            .HasMaxLength(30)
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.Details)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.Neighborhood)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.City)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(u => u.Address)
            .Property(a => a.State)
            .HasMaxLength(200)
            .IsRequired(false);

        builder
            .HasOne(u => u.Tenant)
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.TenantId)
            .IsRequired();

        builder
            .HasMany(u => u.ServiceOrders)
            .WithOne(s => s.Technician)
            .HasForeignKey(s => s.TechnicianId);
    }
}
