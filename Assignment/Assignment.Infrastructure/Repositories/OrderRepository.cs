using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new()
        {
            new Order { OrderId = 1, UserId = 1, OrderDate = DateTime.Parse("2023-11-01"), TotalAmount = 1351.25, Status = "Completed" },
            new Order { OrderId = 2, UserId = 2, OrderDate = DateTime.Parse("2023-11-05"), TotalAmount = 150.75, Status = "Pending" }
        };

        public IEnumerable<Order> GetAllOrders() => _orders;

        public Order GetOrderById(int orderId) => _orders.FirstOrDefault(o => o.OrderId == orderId);

        public void AddOrder(Order order)
        {
            order.OrderId = _orders.Max(o => o.OrderId) + 1; // Auto-increment ID
            _orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = GetOrderById(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.UserId = order.UserId;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.Status = order.Status;
            }
        }

        public void DeleteOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            if (order != null) _orders.Remove(order);
        }
    }
}
