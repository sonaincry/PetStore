using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(CategoryDTO categoryDTO);
        Task<Category> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        Task<bool> SoftDeleteCategoryAsync(int id);
    }
}
