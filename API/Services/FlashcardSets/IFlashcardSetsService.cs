using API.DTOs.FlashcardSetDTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.FlashcardSets
{
    public interface IFlashcardSetsService
    {
        Task<UserFlashcardSetsDTO> GetUserFlashcardSetAsync(int id);
        Task<List<FlashcardSetsDTO>> GetAllFlashcardSetAsync();
        Task<int> AddFlashcardSetAsync(FlashcardSetsDTO flashcardSetsDTO);
        Task DeleteFlashcardSet(int flashcardSet_id);
        Task<bool> FindFlashcardSet(int flashcardSet_id);
    }
}
