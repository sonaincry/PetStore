using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public interface ICartRepository
    {
        Task<Cart> AddOrUpdateCartAsync(int userId);
        Task<Cart> GetCartAsync(int userId);
        Task<bool> RemoveCartAsync(int cartId);
        Task<List<Cart>> GetAllCartsAsync();
    }
}
