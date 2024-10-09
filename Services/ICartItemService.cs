using BusinessObject.DTOs;
using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICartItemService
    {
        Task<CartItem> AddCartItemAsync(CartItemCreateDTO cartItemCreateDTO);
        Task<List<CartItem>> GetCartItemsAsync(int cartId);
        Task<bool> UpdateCartItemAsync(int cartItemId, CartItemUpdateDTO cartItemUpdateDTO);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<bool> ClearCartAsync(int cartId);
        Task<List<CartItem>> GetCartItemByUserId(int userId);
    }
}
