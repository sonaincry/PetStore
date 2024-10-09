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

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> AddOrUpdateCartAsync(CartDTO cartDTO)
        {
            if (cartDTO.UserId == null)
            {
                throw new ArgumentNullException(nameof(cartDTO.UserId), "UserId cannot be null");
            }

            return await _cartRepository.AddOrUpdateCartAsync(cartDTO.UserId.Value);
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
