using API.DTOs.CategoryDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryToListDTO> GetCategoryByIdAsync(int id);
        Task<List<CategoryToListDTO>> GetCategoryAsync();
        Task<int> AddCategoryAsync(CategoryDTO categoryDTO);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> FindCategory(int categoryId);
    }
}
