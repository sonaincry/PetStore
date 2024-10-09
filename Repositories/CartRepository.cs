using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task<Cart> AddOrUpdateCartAsync(int userId)
        {
            return await CartDAO.Instance.AddOrUpdateCartAsync(userId);
        }

        public async Task<Cart> GetCartAsync(int userId)
        {
            return await CartDAO.Instance.GetCartAsync(userId);
        }

        public async Task<bool> RemoveCartAsync(int cartId)
        {
            return await CartDAO.Instance.RemoveCartAsync(cartId);
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await CartDAO.Instance.GetAllCartsAsync();
        }
    }
}
