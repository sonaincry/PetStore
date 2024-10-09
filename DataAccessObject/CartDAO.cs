using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CartDAO
    {
        public static CartDAO instance = null;
        private readonly PetStoreContext dbContext;

        public CartDAO()
        {
            dbContext = new PetStoreContext();
        }

        public static CartDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartDAO();
                }
                return instance;
            }
        }

        public async Task<Cart> AddOrUpdateCartAsync(int userId)
        {
            var existingCart = await dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);
            if (existingCart != null)
            {
                return existingCart;
            }
            else
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    IsDeleted = false
                };
                dbContext.Carts.Add(newCart);
                await dbContext.SaveChangesAsync();
                return newCart;
            }
        }
        public async Task<Cart> GetCartAsync(int userId)
        {
            return await dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);
        }

        public async Task<bool> RemoveCartAsync(int cartId)
        {
            var cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.CartId == cartId && !c.IsDeleted);
            if (cart != null)
            {
                cart.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await dbContext.Carts
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
    }
}
