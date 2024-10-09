using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> AddCategoryAsync(Category category) => CategoryDAO.Instance.AddCategoryAsync(category);
        public Task<List<Category>> GetCategoriesAsync() => CategoryDAO.Instance.GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id) => CategoryDAO.Instance.GetCategoryByIdAsync(id);
        public Task<bool> SoftDeleteCategoryAsync(int id) => CategoryDAO.Instance.SoftDeleteCategoryAsync(id);
        public Task<Category> UpdateCategoryAsync(int id, Category category) => CategoryDAO.Instance.UpdateCategoryAsync(id, category);
    }
}
