using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.CourseDTO;
using API.Services.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Courses
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _service;

        public CoursesController(ICoursesService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByid(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCourseAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("filtered/{id}")]
        public async Task<IActionResult> GetCourses(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCoursesAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("created/{id}")]
        public async Task<IActionResult> GetMyCourses(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetMyCoursesAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody]CourseForAddDTO courseForAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddCourseAsync(courseForAddDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindCourse(id);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteCourse(id);

            return Ok(course);
        }

        [HttpGet("recommendCourses/{userId}")]
        public async Task<IActionResult> RecommendCourses([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.RecommendCoursesAsync(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}