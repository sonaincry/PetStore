using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Category> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                CategoryName = categoryDTO.CategoryName,
                IsDeleted = false
            };
            return await _repository.AddCategoryAsync(category);
        }

        public Task<List<Category>> GetCategoriesAsync() => _repository.GetCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int id) => _repository.GetCategoryByIdAsync(id);

        public Task<bool> SoftDeleteCategoryAsync(int id) => _repository.SoftDeleteCategoryAsync(id);

        public async Task<Category> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                CategoryId = id,
                CategoryName = categoryDTO.CategoryName,
            };
            return await _repository.UpdateCategoryAsync(id, category);
        }
    }
}
