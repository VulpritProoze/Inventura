# Inventura.Domain
The **Heart** of the application. This layer represents the business concepts and rules.

### What lives here:
- **Entities**: Core objects like `Product`, `Transaction`, `Supplier`.
- **Enums**: Constants and status types (e.g., `StockStatus`).
- **Domain Logic**: Business rules that never change (e.g., how to calculate profit).
- **Exceptions**: Custom errors specific to the inventory domain.

### Rule:
- This project must have **zero dependencies** on other projects or external libraries (except core .NET).
