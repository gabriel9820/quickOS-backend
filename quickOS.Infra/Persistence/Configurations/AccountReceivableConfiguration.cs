using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Persistence.Configurations;

public class AccountReceivableConfiguration : IEntityTypeConfiguration<AccountReceivable>
{
    public void Configure(EntityTypeBuilder<AccountReceivable> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(a => a.ExternalId).IsUnique();

        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.UpdatedAt).IsRequired();

        builder.Property(a => a.IssueDate).IsRequired();

        builder.Property(a => a.DueDate).IsRequired();

        builder.Property(a => a.PaymentDate).IsRequired(false);

        builder.Property(a => a.DocumentNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(a => a.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Value).HasPrecision(10, 2).IsRequired();

        builder.Property(a => a.IsPaidOut).IsRequired();

        builder
            .HasOne(a => a.Tenant)
            .WithMany(t => t.AccountsReceivable)
            .HasForeignKey(a => a.TenantId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(a => a.Customer)
            .WithMany(c => c.AccountsReceivable)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder
            .HasOne(a => a.ServiceOrder)
            .WithMany(s => s.AccountsReceivable)
            .HasForeignKey(a => a.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
