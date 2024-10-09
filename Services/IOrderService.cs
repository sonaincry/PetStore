using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(OrderDTO orderDTO);
        Task<Order> UpdateOrderAsync(int id, OrderDTO orderDTO);
        Task<bool> SoftDeleteOrderAsync(int id);

        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> CreateOrderFromProductAsync(int userId, int productId, int quantity);
        Task<Order> CreateOrderFromCartAsync(int cartId);
    }
}
