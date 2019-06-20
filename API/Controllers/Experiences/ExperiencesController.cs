using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.ExperienceDTO;
using API.Repositories.Experiences;
using API.Services.Experiences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Experiences
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceService _service;

        public ExperiencesController(IExperienceService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienceAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExperienceAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetExperiencesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExperiencesAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("user_experience/{id}")]
        public async Task<IActionResult> GetUserExperienceAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserExperienceAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("user_experience_category")]
        public async Task<IActionResult> GetUserExperienceAsync(int userId, int categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserExperienceByCategoryAsync(userId, categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddExperienceAsync([FromBody]ExperienceForListDTO experienceForListDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddExperienceAsync(experienceForListDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindExperience(id);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteExperienceAsync(id);

            return Ok(course);
        }
        [HttpPut("update_experience/{id}")]
        public async Task<IActionResult> UpdateExperienceAsync(int id, ExperienceForListDTO experienceForListDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (experienceForListDTO == null)
            {
                throw new ArgumentNullException(nameof(experienceForListDTO));
            }

            
          
                var result = await _service.UpdateExperienceAsync(id, experienceForListDTO);

            return Ok(result);
        }
    }
}