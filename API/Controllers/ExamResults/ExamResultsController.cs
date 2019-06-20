using System.Threading.Tasks;
using API.DTOs.ExamResultDTO;
using API.Services.ExamResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ExamResults
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultsController : ControllerBase
    {
        private readonly IExamResultsService _service;

        public ExamResultsController(IExamResultsService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserExamResult(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetExamResultsAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("{userId}/exam/{examId}")]
        public async Task<IActionResult> GetCurrentUserExamResultAsync(int userId, int examId) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetCurrentUserExamResultAsync(userId, examId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddExamResult([FromBody]ExamResultListDTO examResultListDTO )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddExamResultAsync(examResultListDTO);
            return Ok(result);
        }
    }
}