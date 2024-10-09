using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int id);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<OrderItem> AddOrderItemAsync(OrderItemCreateDTO orderItemCreateDTO);
        Task<OrderItem> UpdateOrderItemAsync(int id, OrderItemUpdateDTO orderItemUpdateDTO);
        Task<bool> SoftDeleteOrderItemAsync(int id);
    }
}
