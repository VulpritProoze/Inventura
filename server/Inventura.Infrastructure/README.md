# Inventura.Infrastructure
The **Tools** and **Plumbing**. This layer handles technical details and external connections.

### What lives here:
- **Persistence**: EF Core `DbContext` and Database Migrations.
- **Repositories**: Implementation of data access logic (SQL, ORM calls).
- **External Services**: Email senders, File storage, or Payment gateway integration.
- **Identity**: User management and authentication implementation.

### Rule:
- Implements interfaces defined in the **Application** layer.
