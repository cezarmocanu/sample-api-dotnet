using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpringToNet.Domain.Entities;

namespace SpringToNet.Infrastructure.Data.Configurations;

/// <summary>
/// Entity configuration for BusinessAccount
/// </summary>
public class BusinessAccountConfiguration : IEntityTypeConfiguration<BusinessAccount>
{
    public void Configure(EntityTypeBuilder<BusinessAccount> builder)
    {
        // Table name
        builder.ToTable("business_accounts");

        // Primary key
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Properties
        builder.Property(b => b.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.Value)
            .HasColumnName("value")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(b => b.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(b => b.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        // Indexes
        builder.HasIndex(b => b.Name)
            .HasDatabaseName("ix_business_accounts_name");

        builder.HasIndex(b => b.Value)
            .HasDatabaseName("ix_business_accounts_value");
    }
}
