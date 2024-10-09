using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            return await OrderItemDAO.Instance.AddOrderItemAsync(orderItem);
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await OrderItemDAO.Instance.GetOrderItemByIdAsync(id);
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await OrderItemDAO.Instance.GetOrderItemsAsync();
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId) 
        {
            return await OrderItemDAO.Instance.GetOrderItemsByOrderIdAsync(orderId);
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem)
        {
            return await OrderItemDAO.Instance.UpdateOrderItemAsync(id, orderItem);
        }

        public async Task<bool> SoftDeleteOrderItemAsync(int id)
        {
            return await OrderItemDAO.Instance.SoftDeleteOrderItemAsync(id);
        }
    }
}
