[Back to ReadMe](../README.md)

# 📦 Developer Guide

This guide contains common development tasks and conventions used in the project.

## Adding a New Entity

1. Create the Domain Entity.
2. Create the Persistence Record using EF Core scaffolding (or add it manually if required).
3. Create mapping extensions between the Persistence Record and Domain Entity.
4. Create the repository interface.
5. Create the repository implementation.
6. Register dependencies in DI if required.
7. Add unit and integration tests.

## Scaffolding EF Core Models

dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433\SuperApp;Initial Catalog=BaseApp;User ID=sa;Password=Password@123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --project ./src/shared/SuperApp.Infrastructure --context SuperAppDbContext --output-dir Entity --context-dir Contexts --no-onconfiguring

**Notes**

- Generated classes represent Persistence Records, not Domain Entities.
- Do not expose Persistence Records outside the Infrastructure layer.
- Use mapping extensions to convert between Persistence Records and Domain Entities.

## Running Integration Tests

TBA

## Using TestContainers

TBA
