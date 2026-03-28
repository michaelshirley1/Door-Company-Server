namespace BusinessApi.Models;

public class DoorType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Material { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class HingeType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Finish { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class HandleType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Finish { get; set; }
    public string? Mechanism { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Quote> Quotes { get; set; } = [];
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = [];
    public ICollection<Job> Jobs { get; set; } = [];
}

public class Quote
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string QuoteNumber { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    // Draft | Sent | Accepted | Declined | Expired
    public decimal? TotalAmount { get; set; }
    public DateOnly? ValidUntil { get; set; }
    public string? Notes { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Customer Customer { get; set; } = null!;
    public PurchaseOrder? PurchaseOrder { get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
}

public class PurchaseOrder
{
    public int Id { get; set; }
    public int? QuoteId { get; set; }
    public int CustomerId { get; set; }
    public string? PoNumber { get; set; }
    public string Status { get; set; } = "Received";
    // Received | Confirmed | InProduction | Ready | Delivered | Cancelled
    public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public DateOnly? ExpectedDelivery { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Customer Customer { get; set; } = null!;
    public Quote? Quote { get; set; }
    public Job? Job { get; set; }
}

public class Job
{
    public int Id { get; set; }
    public int? PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public string? JobNumber { get; set; }
    public string Status { get; set; } = "Scheduled";
    // Scheduled | InProgress | OnHold | Completed | Cancelled
    public DateOnly? ScheduledDate { get; set; }
    public DateOnly? CompletedDate { get; set; }
    public string? SiteAddress { get; set; }
    public string? AssignedTo { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Customer Customer { get; set; } = null!;
    public PurchaseOrder? PurchaseOrder { get; set; }
    public Invoice? Invoice { get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
}

public class OrderItem
{
    public int Id { get; set; }
    public int? JobId { get; set; }
    public int? QuoteId { get; set; }
    public string ItemType { get; set; } = "Door";

    public int? DoorTypeId { get; set; }
    public int? HingeTypeId { get; set; }
    public int? HandleTypeId { get; set; }

    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public decimal? ThicknessMm { get; set; }

    public string? SwingDirection { get; set; }  // Left | Right | Double | BiFold | Sliding
    public string? ColourFinish { get; set; }
    public string? Glazing { get; set; }
    public string? FireRating { get; set; }
    public string? LocationLabel { get; set; }

    public int Quantity { get; set; } = 1;
    public decimal? UnitPrice { get; set; }

    public string? Notes { get; set; }
    public int SortOrder { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Job? Job { get; set; }
    public Quote? Quote { get; set; }
    public DoorType? DoorType { get; set; }
    public HingeType? HingeType { get; set; }
    public HandleType? HandleType { get; set; }
}

public class Invoice
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string Status { get; set; } = "Draft";
    public decimal Subtotal { get; set; } = 0;
    public decimal TaxRate { get; set; } = 0.15m;  // 15% GST
    public decimal TaxAmount { get; set; } = 0;
    public decimal Total { get; set; } = 0;
    public decimal AmountPaid { get; set; } = 0;
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
    public DateTime? IssuedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Job Job { get; set; } = null!;
}