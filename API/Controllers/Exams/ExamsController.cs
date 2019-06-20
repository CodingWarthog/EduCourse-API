using System.Threading.Tasks;
using API.DTOs.ExamDTO;
using API.Services.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.Exams
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamsController(IExamService service)
        {
            _service = service;
        }

        [HttpGet("courseExams/abcd/{id}")]
        public async Task<IActionResult> GetExamsCreatedByUserAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetExamsABCDFromCourseAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("mob/{id}")]
        public async Task<IActionResult> GetExamsFromCourseAsync(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetExamsFromCourseAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamsFromCourseAngularAsync(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetExamsFromCourseAngularAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("created/{id}")]
        public async Task<IActionResult> GetMyExams(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetNormalExamsCreatedByUserAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("created_draft/{id}")]
        public async Task<IActionResult> GetMyDraftExams(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetDraftExamsCreatedByUserAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("questions/{id}")]
        public async Task<IActionResult> GetExamQuestions(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetQuestionsForExamAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("questions/mob/{id}")]
        public async Task<IActionResult> GetExamQuestionsMob(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetQuestionsForExamMobAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("blocks/{id}")]
        public async Task<IActionResult> GetExamBlocks(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetBlockItemForExamAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("category/{id}")] // tested with postman 
        public async Task<IActionResult> GetCategoryOfExamAsync(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetCategoryOfExamAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("available/{id}")]
        public async Task<IActionResult> GetAllExamsAsync(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetExamsOfEnrolmentCoursesAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam([FromRoute] int id) // nie trzeba
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = await _service.FindExam(id);
            if (exam == false)
            {
                return NotFound();
            }

            await _service.DeleteExam(id);

            return Ok(exam);
        }
        [HttpPost]
        public async Task<IActionResult> AddExam([FromBody]ExamsDTO examsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddExamAsync(examsDTO);
            return Ok(result);
        }
    }
}