-- Database initialization script
-- This runs when PostgreSQL container starts for the first time

-- Create extensions
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Create tables (these will be managed by EF Core migrations in production)
-- This is just for initial setup

-- Grant permissions
GRANT ALL PRIVILEGES ON DATABASE springtonet TO springtonet_user;

-- Set timezone
SET TIME ZONE 'UTC';
