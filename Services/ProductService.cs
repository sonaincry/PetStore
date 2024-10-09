using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsAsync() => await _productRepository.GetProductsAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _productRepository.GetProductByIdAsync(id);

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId) => await _productRepository.GetProductsByCategoryIdAsync(categoryId);

        public async Task<Product> AddProductAsync(ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                ProductName = productCreateDTO.ProductName,
                Description = productCreateDTO.Description,
                Price = productCreateDTO.Price,
                Quantity = productCreateDTO.Quantity,
                CategoryId = productCreateDTO.CategoryId,
                IsDeleted = false
            };

            return await _productRepository.AddProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateDTO productUpdateDTO)
        {
            var product = new Product
            {
                ProductId = id,
                ProductName = productUpdateDTO.ProductName,
                Description = productUpdateDTO.Description,
                Price = productUpdateDTO.Price,
                Quantity = productUpdateDTO.Quantity,
                CategoryId = productUpdateDTO.CategoryId
            };

            return await _productRepository.UpdateProductAsync(id, product);
        }

        public async Task<bool> SoftDeleteProductAsync(int id) => await _productRepository.SoftDeleteProductAsync(id);
    }
}