# Inventura.Web
The **Entry Point**. This is the wrapper that exposes the application to the internet.

### What lives here:
- **Controllers / Minimal APIs**: Handling HTTP requests and status codes.
- **Middleware**: Custom logic for logging, auth, and error handling.
- **Configuration**: Dependency Injection setup in `Program.cs`.
- **Filters**: API-specific attributes and validation filters.

### Rule:
- Only acts as a translator between the user (HTTP) and the **Application** layer.
