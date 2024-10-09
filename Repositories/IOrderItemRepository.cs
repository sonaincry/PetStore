using BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem);
        Task<bool> SoftDeleteOrderItemAsync(int id);
    }
}
