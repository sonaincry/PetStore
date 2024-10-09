using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        public Task<CartItem> AddCartItemAsync(int cartId, int productId, int quantity) => CartItemDAO.Instance.AddCartItemAsync(cartId, productId, quantity);
        public Task<bool> ClearCartAsync(int cartId)=>CartItemDAO.Instance.ClearCartAsync(cartId);

        public Task<List<CartItem>> GetCartItemByUserId(int userId)=>CartItemDAO.Instance.GetCartItemByUserId(userId);

        public Task<List<CartItem>> GetCartItemsAsync(int cartId)=>CartItemDAO.Instance.GetCartItemsAsync(cartId);

        public Task<bool> RemoveCartItemAsync(int cartItemId)=>CartItemDAO.Instance.RemoveCartItemAsync(cartItemId);

        public Task<bool> UpdateCartItemAsync(int cartItemId, int quantity)=>CartItemDAO.Instance.UpdateCartItemAsync(cartItemId, quantity);
    }
}
