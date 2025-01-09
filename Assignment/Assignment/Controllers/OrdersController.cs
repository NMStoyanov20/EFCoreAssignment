using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return Ok(_orderRepository.GetAllOrders());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order newOrder)
        {
            _orderRepository.AddOrder(newOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderId }, newOrder);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order updatedOrder)
        {
            if (id != updatedOrder.OrderId) return BadRequest();
            var existingOrder = _orderRepository.GetOrderById(id);
            if (existingOrder == null) return NotFound();
            _orderRepository.UpdateOrder(updatedOrder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null) return NotFound();
            _orderRepository.DeleteOrder(id);
            return NoContent();
        }
    }
}
