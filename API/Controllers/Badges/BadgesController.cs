using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.BadgeDTO;
using API.Services.Badge;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Badges
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeService _service;

        public BadgesController(IBadgeService service)
        {
           _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBadgeAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetBadgeAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBadgesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetBadgesAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddBadgeAsync([FromBody]BadgeForAddDTO badgesForAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddBadgeAsync(badgesForAddDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBadgeAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindBadgeAsync(id);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteBadgeAsync(id);

            return Ok(course);
        }
        [HttpGet("user_badges/{id}")]
        public async Task<IActionResult> GetUserBadgesAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserBadgesAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("category_badges/{id}")]
        public async Task<IActionResult> GetBadgesByCategoryAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetBadgesByCategoryAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost("assign_badge")]
        public async Task<IActionResult> AssignBadgeAsync([FromBody]AssignBadgeDTO assignBadgeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await _service.AssignBadge(assignBadgeDTO);

            if (result != null)
                return Ok(result);

            return BadRequest();

        }
    }
}