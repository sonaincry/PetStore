using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CartItemDAO
    {
        public static CartItemDAO instance = null;
        private readonly PetStoreContext dbContext;

        public CartItemDAO()
        {
            dbContext = new PetStoreContext();
        }

        public static CartItemDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartItemDAO();
                }
                return instance;
            }
        }

        public async Task<List<CartItem>> GetCartItemsAsync(int cartId)
        {
            return await dbContext.CartItems
                .Where(ci => ci.CartId == cartId && !ci.IsDeleted)
                .ToListAsync();
        }

        public async Task<CartItem> AddCartItemAsync(int cartId, int productId, int quantity)
        {
            var cartExists = await dbContext.Carts.FindAsync(cartId);
            if (cartExists == null)
            {
                throw new ArgumentException("The cart does not exist.");
            }

            var productExists = await dbContext.Products.FindAsync(productId);
            if (productExists == null)
            {
                throw new ArgumentException("The product is not available.");
            }

            if (quantity > productExists.Quantity) 
            {
                throw new ArgumentException($"Product quantity exceeds available stock. Only {productExists.Quantity} available.");
            }

            var existingCartItem = await dbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId && !ci.IsDeleted);

            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity + quantity > productExists.Quantity)
                {
                    throw new ArgumentException($"Total quantity exceeds available stock. Only {productExists.Quantity} available.");
                }

                existingCartItem.Quantity += quantity;
                await dbContext.SaveChangesAsync();
                return existingCartItem;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity,
                    IsDeleted = false
                };

                try
                {
                    await dbContext.CartItems.AddAsync(cartItem);
                    await dbContext.SaveChangesAsync();
                    return cartItem;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("An error occurred while saving the cart item.", ex);
                }
            }
        }

        public async Task<bool> UpdateCartItemAsync(int cartItemId, int quantity)
        {
            try
            {
                var existingCartItem = await dbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId && !ci.IsDeleted);
                if (existingCartItem == null)
                {
                    return false;
                }

                var productExists = await dbContext.Products.FindAsync(existingCartItem.ProductId);
                if (productExists == null)
                {
                    throw new ArgumentException("The product is not available.");
                }
                if (quantity > productExists.Quantity)
                {
                    throw new ArgumentException($"Product quantity exceeds available stock. Only {productExists.Quantity} available.");
                }

                existingCartItem.Quantity = quantity;
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<CartItem>> GetCartItemByUserId(int userId)
        {
            return await dbContext.CartItems
                .Where(c => c.Cart.UserId == userId && !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            var existingCartItem = await dbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartItemId == cartItemId && !ci.IsDeleted);
            if (existingCartItem != null)
            {
                existingCartItem.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ClearCartAsync(int cartId)
        {
            var cartItems = await dbContext.CartItems
                .Where(ci => ci.CartId == cartId && !ci.IsDeleted)
                .ToListAsync();
            foreach (var item in cartItems)
            {
                dbContext.CartItems.Remove(item);
            }
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
