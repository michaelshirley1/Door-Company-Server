using BusinessApi.Interfaces;
using BusinessApi.Models;

namespace BusinessApi.Factories
{
    public interface IQuoteFactory
    {
        Quote? GetById(int id);
        IEnumerable<Quote> GetAll();
    }

    public class QuoteFactory : IQuoteFactory
    {
        private static readonly List<Quote> _quotes =
        [
            new Quote { Id = 1, QuoteNumber = "QTE-001", CustomerName = "Delta Co",   EstimatedAmount = 6000.00m, Status = "Sent",     ExpiresAt = DateTime.UtcNow.AddDays(30) },
            new Quote { Id = 2, QuoteNumber = "QTE-002", CustomerName = "Epsilon LLC", EstimatedAmount = 850.00m,  Status = "Draft",    ExpiresAt = DateTime.UtcNow.AddDays(14) },
            new Quote { Id = 3, QuoteNumber = "QTE-003", CustomerName = "Zeta Group",  EstimatedAmount = 22000.00m,Status = "Accepted", ExpiresAt = DateTime.UtcNow.AddDays(7)  },
        ];

        public Quote? GetById(int id) =>
            _quotes.FirstOrDefault(q => q.Id == id);

        public IEnumerable<Quote> GetAll() => _quotes;
    }
}
