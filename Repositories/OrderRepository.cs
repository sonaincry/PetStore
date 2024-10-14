using BusinessObject.DTOs;
using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetOrdersAsync() => await OrderDAO.Instance.GetOrdersAsync();

        public async Task<Order> GetOrderByIdAsync(int id) => await OrderDAO.Instance.GetOrderByIdAsync(id);

        public async Task<Order> AddOrderAsync(Order order) => await OrderDAO.Instance.AddOrderAsync(order);

        public async Task<Order> UpdateOrderAsync(int id, Order order) => await OrderDAO.Instance.UpdateOrderAsync(id, order);

        public async Task<bool> SoftDeleteOrderAsync(int id) => await OrderDAO.Instance.SoftDeleteOrderAsync(id);

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId) => await OrderDAO.Instance.GetOrdersByUserIdAsync(userId);

        public async Task<Order> CreateOrderFromProductAsync(int userId, int productId, int quantity) => await OrderDAO.Instance.CreateOrderFromProductAsync(userId, productId, quantity);

        public async Task<Order> CreateOrderFromCartAsync(int cartId) => await OrderDAO.Instance.CreateOrderFromCartAsync(cartId);

    }
}
