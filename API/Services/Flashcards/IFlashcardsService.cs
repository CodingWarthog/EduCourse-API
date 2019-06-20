using API.DTOs.FlashcardDTO;
using System.Threading.Tasks;


namespace API.Services.Flashcards
{
    public interface IFlashcardsService
    {
        Task<FlashcardSetForCardsDTO> GetFlashcardsListAsync(int id);
        Task DeleteFlashcardAsync(int flashcard_id);
        Task<bool> FindFlashcardAsync(int flashcard_id);
        Task<int> AddFlashcardAsync(FlashcardListDTO flashcardListDTO);
    }
}
