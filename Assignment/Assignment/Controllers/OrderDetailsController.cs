using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return Ok(_orderDetailRepository.GetAllOrderDetails());
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailById(id);
            if (orderDetail == null) return NotFound();
            return Ok(orderDetail);
        }

        [HttpPost]
        public ActionResult<OrderDetail> CreateOrderDetail(OrderDetail newOrderDetail)
        {
            _orderDetailRepository.AddOrderDetail(newOrderDetail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = newOrderDetail.OrderDetailId }, newOrderDetail);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderDetail(int id, OrderDetail updatedOrderDetail)
        {
            if (id != updatedOrderDetail.OrderDetailId) return BadRequest();
            var existingOrderDetail = _orderDetailRepository.GetOrderDetailById(id);
            if (existingOrderDetail == null) return NotFound();
            _orderDetailRepository.UpdateOrderDetail(updatedOrderDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderDetail(int id)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailById(id);
            if (orderDetail == null) return NotFound();
            _orderDetailRepository.DeleteOrderDetail(id);
            return NoContent();
        }
    }
}
