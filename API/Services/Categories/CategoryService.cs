using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.CategoryDTO;
using API.Models;
using API.Repositories.Categories;
using AutoMapper;

namespace API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _repository.AddCategoryAsync(category);
            return category.Id;
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repository.DeleteCategoryAsync(categoryId);
        }

        public async Task<bool> FindCategory(int categoryId)
        {

            if (await _repository.FindCategory(categoryId) != false)
                return true;
            return false;
        }

        public async Task<List<CategoryToListDTO>> GetCategoryAsync()
        {
            var category = await _repository.GetCategoriesAsync();
            return _mapper.Map<List<CategoryToListDTO>>(category);
        }

        public async Task<CategoryToListDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryAsync(id);
            return _mapper.Map<CategoryToListDTO>(category);
        }
    }
}
