using API.Models;
using System.Threading.Tasks;


namespace API.Repositories.Flashcards
{
    public interface IFlashcardsRepository
    {
        Task<FlashcardSet> GetFlashcardsListAsync(int id);
        Task DeleteFlashcardAsync(int flashcard_id);
        Task<bool> FindFlashcardAsync(int flashcard_id);
        Task AddFlashcardAsync(Flashcard flashcard );
        
    }
}
