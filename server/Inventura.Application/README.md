# Inventura.Application
The **Orchestrator** of the application. This layer defines what the system should *do*.

### What lives here:
- **Interfaces**: Blueprints for repositories and external services (e.g., `IProductRepository`).
- **Services/Use Cases**: High-level logic (e.g., `ProcessSaleService`).
- **DTOs (Data Transfer Objects)**: Objects used to pass data through the API.
- **Validators**: Rules for validating incoming data.

### Rule:
- Depends only on the **Domain** layer.
