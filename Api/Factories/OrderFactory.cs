using BusinessApi.Interfaces;
using BusinessApi.Models;

namespace BusinessApi.Factories
{
    public interface IOrderFactory
    {
        Order? GetById(int id);
        IEnumerable<Order> GetAll();
    }

    public class OrderFactory : IOrderFactory
    {
        private static readonly List<Order> _orders =
        [
            new Order { Id = 1, OrderNumber = "ORD-001", CustomerName = "Acme Corp",    Total = 4800.00m, Status = "Processing" },
            new Order { Id = 2, OrderNumber = "ORD-002", CustomerName = "Beta Ltd",     Total = 920.75m,  Status = "Shipped"    },
            new Order { Id = 3, OrderNumber = "ORD-003", CustomerName = "Gamma Inc",    Total = 12500.00m,Status = "New"        },
        ];

        public Order? GetById(int id) =>
            _orders.FirstOrDefault(o => o.Id == id);

        public IEnumerable<Order> GetAll() => _orders;
    }
}
