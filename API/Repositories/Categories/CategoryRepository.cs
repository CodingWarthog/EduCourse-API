using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly educoursedbContext _context;

        public CategoryRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindCategory(int categoryId)
        {
            if (await _context.Category.FindAsync(categoryId) != null)
                return true;
            return false;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Category.Where(category => category.Id == id).FirstOrDefaultAsync();
        }
    }
}
