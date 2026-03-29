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
            new Quote { Id = 1, QuoteNumber = "QTE-001", },
            new Quote { Id = 2, QuoteNumber = "QTE-002", },
            new Quote { Id = 3, QuoteNumber = "QTE-003", },
        ];

        public Quote? GetById(int id) =>
            _quotes.FirstOrDefault(q => q.Id == id);

        public IEnumerable<Quote> GetAll() => _quotes;
    }
}
