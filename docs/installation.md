[Back to ReadMe](../README.md)

# 📦 Getting Started

## Create Initial Database Migration

Before running the application, create the initial Entity Framework Core migration and apply it to the database.

### Prerequisites

Ensure the EF Core CLI tools are installed:

```bash
dotnet tool install --global dotnet-ef
```

or update an existing installation:

```bash
dotnet tool update --global dotnet-ef
```

### Configure the Design-Time DbContext Factory

Entity Framework Core uses ApplicationDbContextFactory to create the DbContext when generating migrations.

Update the connection string in ApplicationDbContextFactory:

```bash
public class ApplicationDbContextFactory
: IDesignTimeDbContextFactory<ApplicationDbContext>
{
public ApplicationDbContext CreateDbContext(string[] args)
{
var optionsBuilder =
new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=AuthDb;Username=postgres;Password=postgres");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
```

[!NOTE]
This connection string is used only at design time for Entity Framework Core tooling. Ensure it points to the database where migrations should be created and applied.

### Create Migration

From the solution root, run:

```bash
dotnet ef migrations add InitialCreate --project ./src/shared/App.Persistence
```

This command generates the initial database migration based on the current domain model and Entity Framework configurations.

### Apply Migration

Apply the migration to the configured database:

```bash
dotnet ef database update --project ./src/shared/App.Persistence
```

### Verify

After the migration completes successfully, the database should contain:

Application tables (for example, Users, Roles, etc.)
\_\_EFMigrationsHistory

You are now ready to run the application.
