using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> FindCategory(int categoryId);
    }
}
