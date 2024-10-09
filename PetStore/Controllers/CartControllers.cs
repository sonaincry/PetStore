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

        /// <summary>
        /// Add or update a cart.
        /// </summary>
        /// <param name="cartDTO">The cart data transfer object.</param>
        /// <returns>The created or updated cart.</returns>
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

        /// <summary>
        /// Get the cart for a specified user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>The user's cart.</returns>
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

        /// <summary>
        /// Remove a cart by its ID.
        /// </summary>
        /// <param name="cartId">The cart ID.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> RemoveCart(int cartId)
        {
            var result = await _cartService.RemoveCartAsync(cartId);
            if (!result)
            {
                return NotFound($"Cart with ID {cartId} not found.");
            }
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Get all carts.
        /// </summary>
        /// <returns>A list of all carts.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }
    }
}
