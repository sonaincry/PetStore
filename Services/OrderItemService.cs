using AutoMapper;
using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            this.orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItemCreateDTO orderItemCreateDTO)
        {
            var newOrderItem = _mapper.Map<OrderItem>(orderItemCreateDTO);
            return await orderItemRepository.AddOrderItemAsync(newOrderItem);
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int id)
        {
            return await orderItemRepository.GetOrderItemByIdAsync(id);
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await orderItemRepository.GetOrderItemsAsync();
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int id, OrderItemUpdateDTO orderItemUpdateDTO)
        {
            var existingOrderItem = await orderItemRepository.GetOrderItemByIdAsync(id);
            if (existingOrderItem != null)
            {
                _mapper.Map(orderItemUpdateDTO, existingOrderItem);
                return await orderItemRepository.UpdateOrderItemAsync(id, existingOrderItem);
            }
            return null;
        }

        public async Task<bool> SoftDeleteOrderItemAsync(int id)
        {
            return await orderItemRepository.SoftDeleteOrderItemAsync(id);
        }
    }
}
