# Data Access Strategy

This project uses a combination of the **Repository Pattern**, **Specification Pattern**, and **Search Criteria Pattern** to balance maintainability, readability, and flexibility.

### Overview

The data access layer (DAL) serves two distinct querying scenarios:

1. **Business-Oriented Queries** using the Specification Pattern.
2. **Dynamic Search and Filtering** using Search Criteria objects.

The goal is to avoid:

- Repository method explosion.
- Exposing `IQueryable` outside the Infrastructure layer.
- Leaking EF Core implementation details into higher layers.

### Specification Pattern

Specifications are used for **reusable business queries** that represent a meaningful business concept.

### Examples

- Active Users
- Locked Users
- Users With Roles
- Eligible For Login
- Orders Ready For Shipment

### Example

```csharp
public class ActiveUsersSpecification : BaseSpecification<UserRecord>
{
    public ActiveUsersSpecification()
        : base(u => u.IsActive)
    {
    }
}
```

```csharp
var users = await _userRepository.ListAsync(
    new ActiveUsersSpecification());
```

### When to Use

Use a Specification when:

- The query represents a business rule.
- The query will likely be reused.
- The query has a meaningful name within the domain.

### When Not to Use

Avoid using Specifications for:

- Search screens
- Admin grids
- Dynamic filtering
- Reporting queries

These scenarios are better served by Search Criteria objects.

---

### Search Criteria Pattern

Search Criteria objects are used for **dynamic user-driven filtering** where filter values may or may not be supplied.

### Example

```csharp
public class UserSearchCriteria
{
    public string? Username { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }
}
```

### Usage

```csharp
var users = await _userRepository.SearchAsync(criteria);
```

### When to Use

Use Search Criteria when:

- Filters are optional.
- Queries originate from UI or API requests.
- Paging and sorting are required.
- Search requirements frequently change.

### Example Scenarios

- User management screens
- Search endpoints
- Reporting dashboards
- Administrative tools

---

### Repository Responsibilities

Repositories are responsible for:

- Loading aggregates and entities.
- Executing Specifications.
- Executing Search Criteria queries.
- Mapping Persistence Records to Domain Entities.
- Persisting changes.

Repositories should not expose:

- `IQueryable`
- EF Core tracking behavior
- EF Core-specific implementation details

---

### Entity Flow

The project separates Domain Entities from Persistence Records.

```text
UserRecord (Persistence Model)
        ↓
MapToDomain()
        ↓
User (Domain Entity)
        ↓
Domain Behavior
        ↓
Apply Changes
        ↓
UserRecord
        ↓
SaveChanges()
```

This separation prevents EF Core concerns from leaking into the Domain layer and allows the Domain model to evolve independently of the persistence implementation.

---

### Summary

| Pattern         | Purpose                         | Example                  |
| --------------- | ------------------------------- | ------------------------ |
| Specification   | Reusable business query         | ActiveUsersSpecification |
| Search Criteria | Dynamic filtering and searching | UserSearchCriteria       |
| Repository      | Persistence abstraction         | IUserRepository          |

Use Specifications for business concepts and Search Criteria for user-driven searches.
