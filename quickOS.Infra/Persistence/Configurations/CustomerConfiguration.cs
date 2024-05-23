using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.ExternalId).IsUnique();
        builder.HasIndex(c => new { c.Email, c.TenantId }).IsUnique();
        builder.HasIndex(c => new { c.Cellphone, c.TenantId }).IsUnique();
        builder.HasIndex(c => new { c.Document, c.TenantId }).IsUnique();

        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();

        builder.Property(c => c.Type).IsRequired();

        builder.Property(c => c.Document)
            .HasMaxLength(18)
            .IsRequired();

        builder.Property(c => c.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Cellphone)
            .HasMaxLength(15)
            .IsFixedLength()
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.IsActive).IsRequired();

        builder.OwnsOne(c => c.Address)
            .Property(a => a.ZipCode)
            .HasMaxLength(9)
            .IsFixedLength()
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.Street)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.Number)
            .HasMaxLength(30)
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.Details)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.Neighborhood)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.City)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.OwnsOne(c => c.Address)
            .Property(a => a.State)
            .HasMaxLength(200)
            .IsRequired(false);

        builder
            .HasOne(c => c.Tenant)
            .WithMany(t => t.Customers)
            .HasForeignKey(c => c.TenantId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(c => c.ServiceOrders)
            .WithOne(s => s.Customer)
            .HasForeignKey(s => s.CustomerId);
    }
}
