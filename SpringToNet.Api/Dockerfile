# Multi-stage Dockerfile for .NET API
# Similar to Spring Boot Docker builds

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution file
COPY SpringToNet.sln .

# Copy project files
COPY SpringToNet.Api/SpringToNet.Api.csproj SpringToNet.Api/
COPY SpringToNet.Application/SpringToNet.Application.csproj SpringToNet.Application/
COPY SpringToNet.Domain/SpringToNet.Domain.csproj SpringToNet.Domain/
COPY SpringToNet.Infrastructure/SpringToNet.Infrastructure.csproj SpringToNet.Infrastructure/

# Restore dependencies
RUN dotnet restore SpringToNet.sln

# Copy source code
COPY . .

# Build the application
WORKDIR /src/SpringToNet.Api
RUN dotnet build "SpringToNet.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "SpringToNet.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Create non-root user for security
RUN addgroup --group appgroup && adduser --ingroup appgroup --disabled-password appuser
USER appuser

# Copy published app
COPY --from=publish /app/publish .

# Expose port (same as Spring Boot default)
EXPOSE 8080

# Environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

# Entry point
ENTRYPOINT ["dotnet", "SpringToNet.Api.dll"]
