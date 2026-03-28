# Door Company Server — Claude Code Guide

## Project Overview

ASP.NET Core 8 Web API for managing a door company's business operations (jobs, invoices, orders, quotes). Uses the **Controller → Factory** pattern with in-memory data storage.

## Build & Run

```bash
cd Api
dotnet build
dotnet run
```

- HTTPS: https://localhost:64868
- HTTP: http://localhost:64869
- Swagger UI: https://localhost:64868/swagger (Development mode only)

## Project Structure

```
Api/
├── Controllers/      # HTTP endpoint handlers (JobController, InvoiceController, OrderController, QuoteController)
├── Factories/        # Data access layer implementing interfaces with in-memory Lists
├── Models/           # Domain entities (Models.cs)
├── Properties/       # launchSettings.json
├── Program.cs        # App startup, DI registration, Swagger config
└── BusinessApi.csproj
```

## Architecture

Each resource follows: **Model → Interface → Factory → Controller**

- **Factories** are scoped DI services registered in `Program.cs`
- **Controllers** inject factory interfaces via constructor DI
- To swap in a real database: replace in-memory lists in factories only — controllers and interfaces stay untouched

## Domain Model

Key entities in `Api/Models/Models.cs`:
- `Customer` — with relationships to quotes, orders, jobs
- `Quote` — status: Draft | Sent | Accepted | Declined | Expired
- `PurchaseOrder` — status: Received | Confirmed | InProduction | Ready | Delivered | Cancelled
- `Job` — status: Scheduled | InProgress | OnHold | Completed | Cancelled
- `Invoice` — billing with 15% GST default
- `DoorType`, `HingeType`, `HandleType`, `OrderItem` — product specification models

## API Endpoints

| Method | Route          | Description       |
|--------|----------------|-------------------|
| GET    | /job           | Get all jobs      |
| GET    | /job/{id}      | Get job by ID     |
| GET    | /invoice       | Get all invoices  |
| GET    | /invoice/{id}  | Get invoice by ID |
| GET    | /order         | Get all orders    |
| GET    | /order/{id}    | Get order by ID   |
| GET    | /quote         | Get all quotes    |
| GET    | /quote/{id}    | Get quote by ID   |

## Testing

No test projects currently exist.

## Notes

- No database configured yet — all data is in-memory
- No CI/CD workflows configured yet
- Solution file: `Door-Company-Server.sln`
