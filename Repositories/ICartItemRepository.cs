using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetCartItemByUserId(int userId);
        Task<CartItem> AddCartItemAsync(int cartId, int productId, int quantity);
        Task<List<CartItem>> GetCartItemsAsync(int cartId);
        Task<bool> UpdateCartItemAsync(int cartItemId, int quantity);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<bool> ClearCartAsync(int cartId);
    }
}
