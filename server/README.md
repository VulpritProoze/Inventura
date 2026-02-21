# Inventura Server
This is the backend for the Inventura Inventory Management System, following the **Clean Architecture** pattern.

## Project Layers
- **Inventura.Domain**: The core business logic and entities. (Depends on nothing)
- **Inventura.Application**: Use cases and service interfaces. (Depends on Domain)
- **Inventura.Infrastructure**: Database (EF Core), External APIs, and Repository implementations. (Depends on Application & Domain)
- **Inventura.Presentation**: The entry point (ASP.NET Core API). (Depends on Application & Infrastructure)

## Architecture Goal
The goal is to keep the business logic isolated from external concerns like the database or the web framework, making it easily testable and maintainable.
