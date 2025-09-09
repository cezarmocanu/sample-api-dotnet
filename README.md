# SpringToNet - .NET Learning Project

A .NET Web API project designed for Java Spring developers to learn .NET concepts and architecture patterns.

## 🏗️ Architecture

This project demonstrates clean architecture with multiple layers:

```
SpringToNet.Api          # Controllers, DTOs (Spring @RestController)
SpringToNet.Application  # Services, Interfaces (Spring @Service)
SpringToNet.Domain       # Entities, Value Objects (Spring @Entity)
SpringToNet.Infrastructure # Data Access, External Services (Spring @Repository)
SpringToNet.Tests        # Unit Tests (Spring @Test)
```

## 🐳 Docker Setup

### Prerequisites

- Docker & Docker Compose
- .NET 9 SDK (for local development)

### Quick Start with Docker

1. **Clone and navigate to the project:**

   ```bash
   git clone <repo-url>
   cd dotnet-spring-comparison
   ```

2. **Start the application with PostgreSQL:**

   ```bash
   docker-compose up --build
   ```

3. **Access the application:**
   - API: http://localhost:8080
   - Health Check: http://localhost:8080/health
   - Weather API: http://localhost:8080/weatherforecast
   - OpenAPI/Swagger: http://localhost:8080/swagger (in development)
   - pgAdmin: http://localhost:5050 (admin@springtonet.com / admin)

### What Docker Compose Does

The `docker-compose.yml` file:

- ✅ Starts PostgreSQL database (port 5432)
- ✅ Waits for database to be healthy
- ✅ Builds and starts the .NET API (port 8080)
- ✅ Includes pgAdmin for database management (port 5050)
- ✅ Sets up networking between containers
- ✅ Configures health checks
- ✅ Persists database data

## 🗄️ Database Configuration

### Connection String

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=postgres;Port=5432;Database=springtonet;Username=springtonet_user;Password=springtonet_password"
  }
}
```

### Infrastructure Layer Setup

The Infrastructure layer (`SpringToNet.Infrastructure`) contains:

- ✅ PostgreSQL Entity Framework configuration
- ✅ Database context (`ApplicationDbContext`)
- ✅ Entity configurations (equivalent to JPA annotations)
- ✅ Dependency injection setup

## 🔄 Spring Boot vs .NET Comparison

| Spring Boot              | .NET Equivalent             | Purpose                 |
| ------------------------ | --------------------------- | ----------------------- |
| `@SpringBootApplication` | `Program.cs`                | Application entry point |
| `@RestController`        | `Controller` classes        | HTTP endpoints          |
| `@Service`               | Application layer services  | Business logic          |
| `@Repository`            | Infrastructure repositories | Data access             |
| `@Entity`                | Domain entities             | Data models             |
| `@Configuration`         | `DependencyInjection.cs`    | IoC container setup     |
| `application.properties` | `appsettings.json`          | Configuration           |
| `docker-compose.yml`     | `docker-compose.yml`        | Container orchestration |

## 🛠️ Local Development

### Without Docker

1. **Start PostgreSQL locally:**

   ```bash
   # Using Docker for just the database
   docker run --name postgres-dev -e POSTGRES_DB=springtonet -e POSTGRES_USER=springtonet_user -e POSTGRES_PASSWORD=springtonet_password -p 5432:5432 -d postgres:16-alpine
   ```

2. **Run the API:**
   ```bash
   cd SpringToNet.Api
   dotnet run
   ```

### With Docker Development

```bash
# Start only the database
docker-compose up postgres

# Run API locally (connects to containerized database)
cd SpringToNet.Api
dotnet run
```

## 📝 Key .NET Concepts Demonstrated

### 1. **Project Structure**

- **Multi-project solution** (like Maven multi-module)
- **Layer separation** with compile-time enforcement
- **Clean Architecture** principles

### 2. **Dependency Injection**

```csharp
// Infrastructure registration (like Spring @Configuration)
builder.Services.AddInfrastructure(builder.Configuration);
```

### 3. **Entity Configuration**

```csharp
// Instead of JPA annotations in entities
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        // ... configuration
    }
}
```

### 4. **Modern C# Features**

```csharp
// Records for DTOs
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary);

// Init-only properties
public class User
{
    public required string Name { get; init; }
}
```

## 🐛 Troubleshooting

### Database Connection Issues

```bash
# Check if PostgreSQL is running
docker ps

# View logs
docker-compose logs postgres
docker-compose logs api
```

### Port Conflicts

If ports 5432, 8080, or 5050 are in use:

```yaml
# Modify docker-compose.yml ports section
ports:
  - "5433:5432" # Change external port
```

### Build Issues

```bash
# Clean and rebuild
docker-compose down
docker-compose build --no-cache
docker-compose up
```

## 🚀 Next Steps

1. **Add Entity Framework migrations**
2. **Implement repositories and services**
3. **Add authentication (equivalent to Spring Security)**
4. **Add API versioning**
5. **Add comprehensive logging**
6. **Add integration tests**

This project demonstrates the .NET equivalent of a typical Spring Boot application with Docker, PostgreSQL, and clean architecture patterns.
