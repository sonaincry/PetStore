using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderItemDAO
    {
        public static OrderItemDAO instance = null;
        private readonly PetStoreContext dbContext = null;

        public OrderItemDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PetStoreContext();
            }
        }

        public static OrderItemDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderItemDAO();
                }
                return instance;
            }
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await dbContext.OrderItems.Where(oi => !oi.IsDeleted).ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await dbContext.OrderItems.FirstOrDefaultAsync(oi => oi.OrderItemId == id && !oi.IsDeleted);
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await dbContext.OrderItems
                                  .Where(oi => oi.OrderId == orderId && !oi.IsDeleted)
                                  .ToListAsync();
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            await dbContext.OrderItems.AddAsync(orderItem);
            await dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int id, OrderItem orderItem)
        {
            var existOrderItem = await dbContext.OrderItems.FirstOrDefaultAsync(oi => oi.OrderItemId == id && !oi.IsDeleted);
            if (existOrderItem != null)
            {
                existOrderItem.Quantity = orderItem.Quantity ?? existOrderItem.Quantity;
                await dbContext.SaveChangesAsync();
                return existOrderItem;
            }
            return null;
        }

        public async Task<bool> SoftDeleteOrderItemAsync(int id)
        {
            var existOrderItem = await dbContext.OrderItems.FirstOrDefaultAsync(oi => oi.OrderItemId == id && !oi.IsDeleted);
            if (existOrderItem != null)
            {
                existOrderItem.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
