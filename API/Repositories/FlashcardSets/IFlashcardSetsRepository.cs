using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Repositories.Flashcards
{
    public interface IFlashcardSetsRepository
    {
        Task<User> GetUserFlashcardSetAsync(int id);
        Task<List<FlashcardSet>> GetAllFlashCardSetAsync();
        Task AddFlashcardSetAsync(FlashcardSet flashcardSet);
        Task DeleteFlashcardSet(int flashcardSet_id);
        Task<bool> FindFlashcardSet(int flashcardSet_id);
    }
}
