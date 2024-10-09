using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            var newOrder = await _orderService.AddOrderAsync(orderDTO);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.OrderId }, newOrder);
        }

        [HttpPost("direct")]
        public async Task<ActionResult<Order>> CreateOrderFromProduct(int userId, int productId, int quantity)
        {
            var newOrder = await _orderService.CreateOrderFromProductAsync(userId, productId, quantity);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.OrderId }, newOrder);
        }

        [HttpPost("cart")]
        public async Task<ActionResult<Order>> CreateOrderFromCart(int cartId)
        {
            var newOrder = await _orderService.CreateOrderFromCartAsync(cartId);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.OrderId }, newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDTO orderDTO)
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(id, orderDTO);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.SoftDeleteOrderAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
