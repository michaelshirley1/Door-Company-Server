# BusinessApi

A minimal ASP.NET Core 8 Web API using the **Controller → Factory** pattern.

## Project Structure

```
BusinessApi/
├── Controllers/
│   ├── JobController.cs
│   ├── InvoiceController.cs
│   ├── OrderController.cs
│   └── QuoteController.cs
├── Factories/
│   └── Factories.cs          # JobFactory, InvoiceFactory, OrderFactory, QuoteFactory
├── Interfaces/
│   └── IFactories.cs         # IJobFactory, IInvoiceFactory, IOrderFactory, IQuoteFactory
├── Models/
│   └── Models.cs             # Job, Invoice, Order, Quote
├── Program.cs
└── BusinessApi.csproj
```

## Endpoints

| Method | Route          | Description         |
|--------|---------------|---------------------|
| GET    | /job          | Get all jobs        |
| GET    | /job/{id}     | Get job by ID       |
| GET    | /invoice      | Get all invoices    |
| GET    | /invoice/{id} | Get invoice by ID   |
| GET    | /order        | Get all orders      |
| GET    | /order/{id}   | Get order by ID     |
| GET    | /quote        | Get all quotes      |
| GET    | /quote/{id}   | Get quote by ID     |

## Running Locally

```bash
cd BusinessApi
dotnet run
```

Swagger UI is available at `https://localhost:{port}/swagger` in Development mode.

## Architecture

Each resource follows the same pattern:

1. **Model** — plain C# record/class (`Models/Models.cs`)
2. **Interface** — `IXxxFactory` defines `GetById` + `GetAll` (`Interfaces/IFactories.cs`)
3. **Factory** — `XxxFactory` implements the interface with your data source (`Factories/Factories.cs`)
4. **Controller** — injects the factory via constructor DI, maps HTTP routes (`Controllers/`)

To swap in a real database, replace the in-memory lists inside each factory — the controllers and interfaces stay untouched.
