# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
cd Api
dotnet build
dotnet run
```

- HTTPS: https://localhost:64868
- HTTP: http://localhost:64869
- Swagger UI: https://localhost:64868/swagger (Development only)

CORS is allowed from `http://localhost:5173` and `https://localhost:5173` (frontend dev server).

## Architecture

Each resource follows: **Model → Interface → Factory → Controller**

- **Factories** hold the interface and implementation in the same file (`IXxxFactory` + `XxxFactory`)
- **In-memory state** uses `static readonly List<T>` + `static int _nextId` — data resets on restart
- **Factories** are registered as `Scoped` in `Program.cs`; controllers inject via interface
- To add a new resource: create Model → create Factory file (interface + implementation) → create Controller → register in `Program.cs`

## Domain Models

Models are split across individual files in `Api/Models/`:

| File | Types |
|------|-------|
| `Customer.cs` | `Customer` |
| `Job.cs` | `Job` — status: Scheduled \| InProgress \| OnHold \| Completed \| Cancelled |
| `Invoice.cs` | `Invoice` — 15% GST default |
| `Quote.cs` | `Quote`, references `PurchaseOrder`, `OrderItem` — status: Draft \| Sent \| Accepted \| Order \| Declined \| Expired \| Dispatched \| Delivered \| Invoice \| Paid |
| `Order.cs` | `PurchaseOrder`, `OrderItem` — PO status: Received \| Confirmed \| InProduction \| Ready \| Delivered \| Cancelled |
| `Hardware.cs` | `DoorType`, `HingeType`, `HandleType`, `CavitySliderType` |

## API Endpoints

All resources support full CRUD. Routes follow the controller name (lowercase), **except** `CavitySliderTypeController` which uses `[Route("cavity-slider")]`.

| Resource | Base Route | Notes |
|----------|------------|-------|
| Customer | `/customer` | |
| Job | `/job` | |
| Invoice | `/invoice` | |
| Order | `/order` | |
| Quote | `/quote` | |
| DoorType | `/doortype` | |
| HandleType | `/handletype` | |
| HingeType | `/hingetype` | |
| CavitySliderType | `/cavity-slider` | `GET /cavity-slider` accepts `?supplier=`, `?heightMm=`, `?category=`, `?isPOA=` query filters |

Standard CRUD pattern per resource:
- `GET /resource` — get all
- `GET /resource/{id}` — get by ID (404 if missing)
- `POST /resource` — create (returns 201 with `Location` header)
- `PUT /resource/{id}` — full update (404 if missing)
- `DELETE /resource/{id}` — delete (204 on success, 404 if missing)

## JSON Serialization

Global options in `Program.cs`:
- `ReferenceHandler.IgnoreCycles` — prevents infinite loops on circular nav properties
- `DefaultIgnoreCondition.WhenWritingNull` — null fields are omitted from responses

## Notes

- No database — all data is in-memory and lost on restart
- No tests exist yet
- Solution file: `Door-Company-Server.sln`
