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
            new Invoice { Id = 1, InvoiceNumber = "INV-001" },
            new Invoice { Id = 2, InvoiceNumber = "INV-002" },
            new Invoice { Id = 3, InvoiceNumber = "INV-003" },
        ];

        public Invoice? GetById(int id) =>
            _invoices.FirstOrDefault(i => i.Id == id);

        public IEnumerable<Invoice> GetAll() => _invoices;
    }
}
