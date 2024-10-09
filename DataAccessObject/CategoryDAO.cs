using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO
    {
        public static CategoryDAO instance = null;
        private readonly PetStoreContext dbContext = null;

        public CategoryDAO()
        {
            if (dbContext == null)
            {
                dbContext = new PetStoreContext();
            }
        }

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id && !c.IsDeleted);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var existCategory = await GetCategoryByIdAsync(id);
            if (existCategory != null)
            {
                existCategory.CategoryName = category.CategoryName ?? existCategory.CategoryName;
                await dbContext.SaveChangesAsync();
                return existCategory;
            }
            return null;
        }

        public async Task<bool> SoftDeleteCategoryAsync(int id)
        {
            var existCategory = await GetCategoryByIdAsync(id);
            if (existCategory != null)
            {
                existCategory.IsDeleted = true;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
