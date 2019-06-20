using API.DTOs.FlashcardSetDTO;
using API.Models;
using API.Repositories.Flashcards;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace API.Services.FlashcardSets
{
    public class FlashcardSetsService : IFlashcardSetsService
    {
        private readonly IFlashcardSetsRepository _repository;
        private readonly IMapper _mapper;

        public FlashcardSetsService(IFlashcardSetsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddFlashcardSetAsync(FlashcardSetsDTO flashcardSetsDTO)
        {
            var flashcardSets = _mapper.Map<FlashcardSet>(flashcardSetsDTO);
            await _repository.AddFlashcardSetAsync(flashcardSets);
            return flashcardSets.Id;
        }

        public async Task DeleteFlashcardSet(int flashcardSet_id)
        {
            await _repository.DeleteFlashcardSet(flashcardSet_id);
        }

        public async Task<bool> FindFlashcardSet(int flashcardSet_id)
        {
            if (await _repository.FindFlashcardSet(flashcardSet_id) != false)
                return true;
            return false;
        }

        public async Task<List<FlashcardSetsDTO>> GetAllFlashcardSetAsync()
        {
            var flashcardSets = await _repository.GetAllFlashCardSetAsync();
            return _mapper.Map<List<FlashcardSetsDTO>>(flashcardSets);
        }

        public async Task<UserFlashcardSetsDTO> GetUserFlashcardSetAsync(int id)
        {
            var exams = await _repository.GetUserFlashcardSetAsync(id);
            return _mapper.Map<UserFlashcardSetsDTO>(exams);
        }
    }
}
