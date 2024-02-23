﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quickOS.Core.Entities;

namespace quickOS.Infra.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.ExternalId).IsUnique();

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();

        builder.Property(u => u.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.CellPhone)
            .HasMaxLength(14)
            .IsFixedLength()
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Password).IsRequired();

        builder.Property(u => u.IsActive).IsRequired();

        builder.Property(u => u.Role).IsRequired();

        builder
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId);
    }
}
