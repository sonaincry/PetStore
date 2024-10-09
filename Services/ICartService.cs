using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICartService
    {
        Task<Cart> AddOrUpdateCartAsync(CartDTO cartDTO);
        Task<Cart> GetCartAsync(int userId);
        Task<bool> RemoveCartAsync(int cartId);
        Task<List<Cart>> GetAllCartsAsync();
    }
}
