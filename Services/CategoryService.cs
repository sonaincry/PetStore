using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return await _repository.AddCategoryAsync(category);
        }

        public Task<List<Category>> GetCategoriesAsync() => _repository.GetCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int id) => _repository.GetCategoryByIdAsync(id);

        public Task<bool> SoftDeleteCategoryAsync(int id) => _repository.SoftDeleteCategoryAsync(id);

        public async Task<Category> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return await _repository.UpdateCategoryAsync(id, category);
        }
    }
}
