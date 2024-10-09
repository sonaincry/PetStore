using AutoMapper;
using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrdersAsync() => await _orderRepository.GetOrdersAsync();

        public async Task<Order> GetOrderByIdAsync(int id) => await _orderRepository.GetOrderByIdAsync(id);

        public async Task<Order> AddOrderAsync(OrderDTO orderDTO)
        {
            var newOrder = _mapper.Map<Order>(orderDTO); 

            return await _orderRepository.AddOrderAsync(newOrder);
        }

        public async Task<Order> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder != null)
            {
                _mapper.Map(orderDTO, existingOrder);

                return await _orderRepository.UpdateOrderAsync(id, existingOrder);
            }

            return null;
        }

        public async Task<bool> SoftDeleteOrderAsync(int id) => await _orderRepository.SoftDeleteOrderAsync(id);

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId) => await _orderRepository.GetOrdersByUserIdAsync(userId);

        public async Task<Order> CreateOrderFromProductAsync(int userId, int productId, int quantity)
        {
            return await _orderRepository.CreateOrderFromProductAsync(userId, productId, quantity);
        }

        public async Task<Order> CreateOrderFromCartAsync(int cartId)
        {
            return await _orderRepository.CreateOrderFromCartAsync(cartId);
        }
    }
}
