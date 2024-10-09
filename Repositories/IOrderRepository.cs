using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<bool> SoftDeleteOrderAsync(int id);
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> CreateOrderFromProductAsync(int userId, int productId, int quantity);
        Task<Order> CreateOrderFromCartAsync(int cartId);
    }
}
