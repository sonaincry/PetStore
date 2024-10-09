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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var orderItems = await _orderItemService.GetOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpGet("ByOrder/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItemsByOrderId(int orderId)
        {
            var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
            if (orderItems == null || orderItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(orderItems);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItemCreateDTO orderItemDTO)
        {
            var newOrderItem = await _orderItemService.AddOrderItemAsync(orderItemDTO);
            return CreatedAtAction(nameof(GetOrderItem), new { id = newOrderItem.OrderItemId }, newOrderItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItemUpdateDTO orderItemDTO)
        {
            var updatedOrderItem = await _orderItemService.UpdateOrderItemAsync(id, orderItemDTO);
            if (updatedOrderItem == null)
            {
                return NotFound();
            }
            return Ok(updatedOrderItem);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var result = await _orderItemService.SoftDeleteOrderItemAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
