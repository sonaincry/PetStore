using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> AddProductAsync(Product product) => await ProductDAO.Instance.AddProductAsync(product);

        public async Task<Product> GetProductByIdAsync(int id) => await ProductDAO.Instance.GetProductByIdAsync(id);

        public async Task<List<Product>> GetProductsAsync() => await ProductDAO.Instance.GetProductsAsync();

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId) => await ProductDAO.Instance.GetProductsByCategoryIdAsync(categoryId);

        public async Task<Product> UpdateProductAsync(int id, Product product) => await ProductDAO.Instance.UpdateProductAsync(id, product);

        public async Task<bool> SoftDeleteProductAsync(int id) => await ProductDAO.Instance.SoftDeleteProductAsync(id);
    }
}
