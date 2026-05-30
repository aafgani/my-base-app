Decision:
Separate Domain Entity and Persistence Model.

Why:

- Prevent EF Core leakage.
- Enable richer domain model.
- Support Dapper and EF coexistence.

Consequences:

- Additional mapping required.
- Some update scenarios may require re-querying.

Consequences:

- Additional mapping required.
- Some update scenarios may require re-querying.
