using AutoMapper;
using BusinessObject.Models;
using BusinessObject.Models.DTO;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<Cart> AddOrUpdateCartAsync(CartDTO cartDTO)
        {

            var cart = _mapper.Map<Cart>(cartDTO);
            if (cart.UserId == null)
            {
                throw new ArgumentNullException(nameof(cartDTO.UserId), "UserId cannot be null");
            }

            return await _cartRepository.AddOrUpdateCartAsync(cart.UserId.Value);
        }

        public async Task<Cart> GetCartAsync(int userId)
        {
            return await _cartRepository.GetCartAsync(userId);
        }

        public async Task<bool> RemoveCartAsync(int cartId)
        {
            return await _cartRepository.RemoveCartAsync(cartId);
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _cartRepository.GetAllCartsAsync();
        }
    }
}
