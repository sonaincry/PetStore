using BusinessObject.DTOs;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private readonly PetStoreContext dbContext = null;

        private OrderDAO()
        {
            dbContext = new PetStoreContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await dbContext.Orders
                                  .Where(o => !o.IsDeleted)
                                  .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await dbContext.Orders
                                  .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDeleted);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(int id, Order updatedOrder)
        {
            var existOrder = await dbContext.Orders
                                            .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDeleted);
            if (existOrder != null)
            {
                existOrder.Total = updatedOrder.Total ?? existOrder.Total;
                existOrder.UserId = updatedOrder.UserId ?? existOrder.UserId;

                await dbContext.SaveChangesAsync();
                return existOrder;
            }
            return null;
        }

        public async Task<bool> SoftDeleteOrderAsync(int id)
        {
            var existOrder = await dbContext.Orders
                                            .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDeleted);
            if (existOrder != null)
            {
                existOrder.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await dbContext.Orders
                                  .Where(o => o.UserId == userId && !o.IsDeleted)
                                  .ToListAsync();
        }
        public async Task<Order> CreateOrderFromProductAsync(int userId, int productId, int quantity)
        {
            try
            {
                var product = await dbContext.Products.FindAsync(productId);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }


                decimal totalAmount = product.Price * quantity;

                var order = new Order
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Total = totalAmount
                };

                await AddOrderAsync(order);

                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = productId,
                    Quantity = quantity,
                    IsDeleted = false
                };

                await dbContext.OrderItems.AddAsync(orderItem);

                var paymentDetail = new PaymentDetail
                {
                    OrderId = order.OrderId,
                    Amount = totalAmount,
                    PaymentMethod = "pay when receive",
                    PaymentStatus = "Pending"
                };

                await dbContext.PaymentDetails.AddAsync(paymentDetail);

                await dbContext.SaveChangesAsync();

                return order;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<Order> CreateOrderFromCartAsync(int cartId)
        {
            try
            {
                var cart = await dbContext.Carts
                                       .Include(c => c.CartItems)
                                       .ThenInclude(ci => ci.Product)
                                       .FirstOrDefaultAsync(c => c.CartId == cartId && !c.IsDeleted);

                if (cart == null)
                {
                    throw new Exception("Cart not found.");
                }

                decimal total = 0;
                foreach (var item in cart.CartItems)
                {
                    var product = await dbContext.Products.FindAsync(item.ProductId);
                    if (product != null)
                    {
                        total += product.Price * item.Quantity;
                    }
                }

                var order = new Order
                {
                    UserId = cart.UserId,
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Total = total
                };

                await AddOrderAsync(order);

                foreach (var item in cart.CartItems)
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        IsDeleted = false
                    };

                    await dbContext.OrderItems.AddAsync(orderItem);
                }

                await dbContext.SaveChangesAsync();


                var paymentDetail = new PaymentDetail
                {
                    OrderId = order.OrderId,
                    Amount = total,
                    PaymentMethod = "Pay when receive",
                    PaymentStatus = "Pending"
                };

                await PaymentDetailDAO.Instance.AddPaymentDetailAsync(paymentDetail);

                var cartItemDAO = CartItemDAO.Instance;
                await cartItemDAO.ClearCartAsync(cartId);

                return order;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }

}