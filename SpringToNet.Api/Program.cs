using SpringToNet.Domain.Entities;
using SpringToNet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Swagger UI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Infrastructure layer (PostgreSQL, repositories, etc.)
// builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Health check endpoint for Docker
app.MapGet("/business-accounts", () =>
{

    // Return a sample BusinessAccount as the health check response
    return Results.Ok(new BusinessAccount
    {
        Name = "HealthCheck Account",
        Value = 0,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    });
})
.WithName("BusinessAccounts");

// Health check endpoint for Docker
app.MapGet("/health", () =>
{

    // Return a sample BusinessAccount as the health check response
    return Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
})
.WithName("HealthCheck");

app.Run();

