using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpringToNet.Infrastructure.Data;

namespace SpringToNet.Infrastructure;

/// <summary>
/// Infrastructure dependency injection configuration
/// Equivalent to Spring Boot @Configuration classes
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add database context with PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Add repositories and other infrastructure services here
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IBusinessAccountRepository, BusinessAccountRepository>();

        return services;
    }
}
