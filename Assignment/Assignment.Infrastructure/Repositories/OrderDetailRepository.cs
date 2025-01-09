using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;

namespace Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly List<OrderDetail> _orderDetails = new()
        {
            new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, PricePerUnit = 1200.50 },
            new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 2, Quantity = 1, PricePerUnit = 150.75 },
            new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 2, Quantity = 1, PricePerUnit = 150.75 }
        };

        public IEnumerable<OrderDetail> GetAllOrderDetails() => _orderDetails;

        public OrderDetail GetOrderDetailById(int orderDetailId) => _orderDetails.FirstOrDefault(od => od.OrderDetailId == orderDetailId);

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetail.OrderDetailId = _orderDetails.Max(od => od.OrderDetailId) + 1; // Auto-increment ID
            _orderDetails.Add(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail = GetOrderDetailById(orderDetail.OrderDetailId);
            if (existingOrderDetail != null)
            {
                existingOrderDetail.OrderId = orderDetail.OrderId;
                existingOrderDetail.ProductId = orderDetail.ProductId;
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.PricePerUnit = orderDetail.PricePerUnit;
            }
        }

        public void DeleteOrderDetail(int orderDetailId)
        {
            var orderDetail = GetOrderDetailById(orderDetailId);
            if (orderDetail != null) _orderDetails.Remove(orderDetail);
        }
    }
}
