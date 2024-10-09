using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartItem> AddCartItemAsync(CartItemCreateDTO cartItemCreateDTO)
        {
            return await _cartItemRepository.AddCartItemAsync(cartItemCreateDTO.CartId, cartItemCreateDTO.ProductId, cartItemCreateDTO.Quantity);
        }

        public async Task<List<CartItem>> GetCartItemsAsync(int cartId)
        {
            return await _cartItemRepository.GetCartItemsAsync(cartId);
        }

        public async Task<bool> UpdateCartItemAsync(int cartItemId, CartItemUpdateDTO cartItemUpdateDTO)
        {
            return await _cartItemRepository.UpdateCartItemAsync(cartItemId, cartItemUpdateDTO.Quantity);
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            return await _cartItemRepository.RemoveCartItemAsync(cartItemId);
        }

        public async Task<bool> ClearCartAsync(int cartId)
        {
            return await _cartItemRepository.ClearCartAsync(cartId);
        }

        public async Task<List<CartItem>> GetCartItemByUserId(int userId)
        {
            return await _cartItemRepository.GetCartItemByUserId(userId);
        }
    }
}
