using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCart([FromBody] CartDTO cartDTO)
        {
            if (cartDTO == null)
            {
                return BadRequest("Cart data cannot be null.");
            }

            var cart = await _cartService.AddOrUpdateCartAsync(cartDTO);
            return CreatedAtAction(nameof(GetCart), new { userId = cartDTO.UserId }, cart);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            if (cart == null)
            {
                return NotFound($"Cart for user ID {userId} not found.");
            }
            return Ok(cart);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> RemoveCart(int cartId)
        {
            var result = await _cartService.RemoveCartAsync(cartId);
            if (!result)
            {
                return NotFound($"Cart with ID {cartId} not found.");
            }
            return NoContent(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }
    }
}
