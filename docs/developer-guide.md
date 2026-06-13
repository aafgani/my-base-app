[Back to ReadMe](../README.md)

# 📦 Developer Guide

This guide contains common development tasks and conventions used in the project.

## Initial Database Setup

Before scaffolding EF Core models, ensure the database schema has been deployed from the SQL Database Project.

1. Build the database project.
2. Publish the generated DACPAC to the target SQL Server instance.
3. Verify that the database and schema objects have been created successfully.

### Adding a New Entity

1. Create or update the database object in the SQL Database Project.
2. Deploy the database project to the target database.
3. Create the Persistence Record using EF Core scaffolding (or add it manually if required).
4. Create the Domain Entity.
5. Create mapping extensions between the Persistence Record and Domain Entity.
6. Create the repository interface.
7. Create the repository implementation.
8. Register dependencies in DI if required.
9. Add unit and integration tests.

### Scaffolding EF Core Models

dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433\BaseApp;Initial Catalog=BaseApp;User ID=sa;Password=Password@123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --project ./src/shared/App.Infrastructure --context AppDbContext --output-dir Persistence/Records --context-dir Persistence/Contexts --no-onconfiguring

**Notes**

- Generated classes represent Persistence Records, not Domain Entities.
- Do not expose Persistence Records outside the Infrastructure layer.
- Use mapping extensions to convert between Persistence Records and Domain Entities.

## Test

### Running Integration Tests

TBA

### Using TestContainers

TBA
