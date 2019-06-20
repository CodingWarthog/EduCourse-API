using System.Threading.Tasks;
using API.DTOs.FlashcardSetDTO;
using API.Services.FlashcardSets;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.Flashcards
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardSetsController : ControllerBase
    {
        private readonly IFlashcardSetsService _flashcardSetService;

        public FlashcardSetsController(IFlashcardSetsService flashcardSetService)
        {
           _flashcardSetService = flashcardSetService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFlashcardSets(int id) // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _flashcardSetService.GetUserFlashcardSetAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFlashcardSets()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _flashcardSetService.GetAllFlashcardSetAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlashcardSet([FromBody]FlashcardSetsDTO flashcardSetsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _flashcardSetService.AddFlashcardSetAsync(flashcardSetsDTO);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcardSet([FromRoute] int id)   // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flashcardSet = await _flashcardSetService.FindFlashcardSet(id);
            if (flashcardSet == false)
            {
                return NotFound();
            }

            await _flashcardSetService.DeleteFlashcardSet(id);

            return Ok(flashcardSet);
        }
    }
}
