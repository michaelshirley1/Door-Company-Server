using BusinessApi.Interfaces;
using BusinessApi.Models;

namespace BusinessApi.Factories
{
    public interface IInvoiceFactory
    {
        Invoice? GetById(int id);
        IEnumerable<Invoice> GetAll();
    }

    public class InvoiceFactory : IInvoiceFactory
    {
        private static readonly List<Invoice> _invoices =
        [
            new Invoice { Id = 1, InvoiceNumber = "INV-001", Amount = 1500.00m, Status = "Paid",    DueDate = DateTime.UtcNow.AddDays(-10) },
            new Invoice { Id = 2, InvoiceNumber = "INV-002", Amount = 3200.50m, Status = "Unpaid",  DueDate = DateTime.UtcNow.AddDays(15)  },
            new Invoice { Id = 3, InvoiceNumber = "INV-003", Amount = 750.00m,  Status = "Overdue", DueDate = DateTime.UtcNow.AddDays(-5)  },
        ];

        public Invoice? GetById(int id) =>
            _invoices.FirstOrDefault(i => i.Id == id);

        public IEnumerable<Invoice> GetAll() => _invoices;
    }
}
