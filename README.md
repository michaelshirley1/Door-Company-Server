# Door Company Server — .NET Backend

REST API backend for the door company management platform, built with ASP.NET Core 8

This repository is an early-stage business API serving jobs, quotes, orders, customers, and product catalogue data to the React frontend.

## What it is

JSON API supporting:

- **Jobs** — installation job lifecycle from scheduled through to completed
- **Quotes** — quote management from draft through to paid
- **Orders** — purchase orders and line items with door/hardware specs
- **Customers** — customer records linked to quotes, orders, and jobs
- **Catalogue** — doors, cavity sliders, hinges, and handles

## Project structure

```
Api/
  Controllers/    HTTP endpoint handlers, one per resource
  Factories/      in-memory data layer — interface and implementation per resource
  Models/         domain entities split by area
  Program.cs      DI registration, CORS, Swagger config
```

Each resource follows: `Model` → `IXxxFactory` + `XxxFactory` → `XxxController`

## Commands

```bash
cd Api
dotnet build
dotnet run
```

- API: https://localhost:64868
- Swagger UI: https://localhost:64868/swagger

## Built with

- ASP.NET Core 8
- C# in-memory data (no database yet)
- Swagger / Swashbuckle
- React frontend at http://localhost:5173
