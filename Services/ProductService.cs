using AutoMapper; 
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
        private readonly IMapper _mapper; 

        public ProductService(IProductRepository productRepository, IMapper mapper) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetProductsAsync() => await _productRepository.GetProductsAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _productRepository.GetProductByIdAsync(id);

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId) => await _productRepository.GetProductsByCategoryIdAsync(categoryId);

        public async Task<Product> AddProductAsync(ProductCreateDTO productCreateDTO)
        {

            var product = _mapper.Map<Product>(productCreateDTO);
            product.IsDeleted = false; 

            return await _productRepository.AddProductAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateDTO productUpdateDTO)
        {

            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct != null)
            {
               
                _mapper.Map(productUpdateDTO, existingProduct);
                existingProduct.ProductId = id; 
                return await _productRepository.UpdateProductAsync(id, existingProduct);
            }
            return null; 
        }

        public async Task<bool> SoftDeleteProductAsync(int id) => await _productRepository.SoftDeleteProductAsync(id);
    }
}
