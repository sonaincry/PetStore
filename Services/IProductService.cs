using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<Product> AddProductAsync(ProductCreateDTO productCreateDTO);
        Task<Product> UpdateProductAsync(int id, ProductUpdateDTO productUpdateDTO);
        Task<bool> SoftDeleteProductAsync(int id);
    }
}