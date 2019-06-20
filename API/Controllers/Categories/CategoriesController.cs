using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.CategoryDTO;
using API.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByidAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCategoryByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCategoryAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody]CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddCategoryAsync(categoryDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindCategory(id);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteCategoryAsync(id);

            return Ok(course);
        }
    }
}