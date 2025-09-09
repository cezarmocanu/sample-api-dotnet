using Microsoft.EntityFrameworkCore;
using SpringToNet.Domain.Entities;

namespace SpringToNet.Infrastructure.Data;

/// <summary>
/// Database context - equivalent to Spring Boot JPA configuration
/// This is where we configure our entities for the database
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets - equivalent to Spring Data JPA repositories
    public DbSet<User> Users { get; set; }
    public DbSet<BusinessAccount> BusinessAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
