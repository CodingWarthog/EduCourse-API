using System.Threading.Tasks;
using API.DTOs.CourseEnrolmentDTO;
using API.Services.CourseEnrolments;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.CourseEnrolments
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrolmentsController : ControllerBase
    {
        private readonly ICourseEnrolmentsService _service;

        public CourseEnrolmentsController(ICourseEnrolmentsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> EnrolCourse([FromBody]EnrolDTO enrolDTO )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _service.FindUser(enrolDTO.UserId);
            if (user == false)
            {
                return Unauthorized();
            }
            var course = await _service.FindCourse(enrolDTO.CourseId);
            if (course == false)
            {
                return NotFound("Wybrany kurs nie istnieje");
            }
            var courseEnrolment = await _service.FindCourseEnrolment(enrolDTO.UserId, enrolDTO.CourseId);
            if (courseEnrolment == true)
            {
                return BadRequest("Już jesteś zapisany na ten kurs");
            }
            var result = await _service.EnrolCourseAsync(enrolDTO);

            if (result != null)
                return Ok(result);

            return BadRequest("Nie zostałeś zapisany na kurs");

        }
        [HttpDelete("for_delete")]
        public async Task<IActionResult> DeleteEnrolment(int user_id, int course_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
     
            var user = await _service.FindUser(user_id);
            if (user == false)
            {
                return Unauthorized();
            }
            var courseEnrolment = await _service.FindCourseEnrolment(user_id, course_id);
            if (courseEnrolment == false)
            {
                return NotFound("Taki zapis nie istnieje");
            }

            var result = await _service.DeleteEnrolment(user_id, course_id);

            if (result == true)
                return Ok(result);

            return BadRequest("Zapis na kurs nie został usunięty");

        }


    }
}