using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductDAO
    {
        public static ProductDAO instance = null;
        private readonly PetStoreContext dbContext = null;

        public ProductDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PetStoreContext();
            }
        }

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await dbContext.Products.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await dbContext.Products
                                  .Where(p => p.CategoryId == categoryId && !p.IsDeleted)
                                  .ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                if (dbContext.Products.Any(u => u.ProductName == u.ProductName))
                {
                    throw new Exception("This product already exist.");
                }
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product.", ex);
            }
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            try
            {
                var existProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);
                if (existProduct != null)
                {
                    existProduct.ProductName = product.ProductName ?? existProduct.ProductName;
                    existProduct.Description = product.Description ?? existProduct.Description;
                    existProduct.Price = product.Price > 0 ? product.Price : existProduct.Price;
                    existProduct.Quantity = product.Quantity >= 0 ? product.Quantity : existProduct.Quantity;
                    existProduct.DiscountId = product.DiscountId ?? existProduct.DiscountId;
                    existProduct.CategoryId = product.CategoryId ?? existProduct.CategoryId;

                    await dbContext.SaveChangesAsync();
                    return existProduct;
                }
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product.", ex);
            }
        }

        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            var existProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);
            if (existProduct != null)
            {
                existProduct.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
