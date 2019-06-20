using System.Threading.Tasks;
using API.DTOs.FlashcardDTO;
using API.Services.Flashcards;
using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers.Flashcards
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IFlashcardsService _flashcardsService;

        public FlashcardsController(IFlashcardsService flashcardsService)
        {
            _flashcardsService = flashcardsService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flashcard = await _flashcardsService.FindFlashcardAsync(id);
            if (flashcard == false)
            { 
                return NotFound();
            }

            await _flashcardsService.DeleteFlashcardAsync(id);

            return Ok(flashcard);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlashcard([FromBody]FlashcardListDTO flashcardListDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _flashcardsService.AddFlashcardAsync(flashcardListDTO);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlashcardList(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _flashcardsService.GetFlashcardsListAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
