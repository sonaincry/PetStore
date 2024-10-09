using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<CartItem>>> GetCart(int userId)
        {
            var cart = await _cartItemService.GetCartItemByUserId(userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpGet("items/{cartId}")]
        public async Task<ActionResult<List<CartItem>>> GetCartItems(int cartId)
        {
            var cartItems = await _cartItemService.GetCartItemsAsync(cartId);
            return Ok(cartItems);
        }

        [HttpPost]
        public async Task<ActionResult<CartItem>> AddCartItem([FromBody] CartItemCreateDTO cartItemCreateDTO)
        {
            var cartItem = await _cartItemService.AddCartItemAsync(cartItemCreateDTO);
            return CreatedAtAction(nameof(GetCartItems), new { cartId = cartItem.CartId }, cartItem);
        }

        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, [FromBody] CartItemUpdateDTO cartItemUpdateDTO)
        {
            var success = await _cartItemService.UpdateCartItemAsync(cartItemId, cartItemUpdateDTO);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            var success = await _cartItemService.RemoveCartItemAsync(cartItemId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("clear/{cartId}")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            var success = await _cartItemService.ClearCartAsync(cartId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
