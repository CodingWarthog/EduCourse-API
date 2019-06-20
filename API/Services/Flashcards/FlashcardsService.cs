using API.DTOs.FlashcardDTO;
using API.Models;
using API.Repositories.Flashcards;
using AutoMapper;
using System.Threading.Tasks;


namespace API.Services.Flashcards
{
    public class FlashcardsService : IFlashcardsService
    {
        private readonly IFlashcardsRepository _repository;
        private readonly IMapper _mapper;

        public FlashcardsService(IFlashcardsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddFlashcardAsync(FlashcardListDTO flashcardListDTO)
        {
            var flashcardToAdd = _mapper.Map<Flashcard>(flashcardListDTO);
            await _repository.AddFlashcardAsync(flashcardToAdd);
            return flashcardToAdd.Id;
        }

        public async Task DeleteFlashcardAsync(int flashcard_id)
        {
            await _repository.DeleteFlashcardAsync(flashcard_id);
        }

        public async Task<bool> FindFlashcardAsync(int flashcard_id)
        {
            if (await _repository.FindFlashcardAsync(flashcard_id) != false)
                return true;
            return false;
        }

        public async Task<FlashcardSetForCardsDTO> GetFlashcardsListAsync(int id)
        {
            var flashcard = await _repository.GetFlashcardsListAsync(id);
            return _mapper.Map<FlashcardSetForCardsDTO>(flashcard);
        }
    }
}
