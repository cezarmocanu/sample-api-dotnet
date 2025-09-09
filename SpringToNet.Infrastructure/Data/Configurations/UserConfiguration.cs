using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpringToNet.Domain.Entities;

namespace SpringToNet.Infrastructure.Data.Configurations;

/// <summary>
/// Entity configuration - equivalent to Spring Boot JPA @Entity annotations
/// This is where we define database mapping for User entity
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name
        builder.ToTable("users");

        // Primary key
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd(); // Auto-increment

        // Properties
        builder.Property(u => u.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        // Indexes
        builder.HasIndex(u => u.Name)
            .HasDatabaseName("ix_users_name");
    }
}
