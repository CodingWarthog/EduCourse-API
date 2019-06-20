using API.DTOs.ExamResultDTO;
using API.Models;
using API.Repositories.ExamResults;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace API.Services.ExamResults
{
    public class ExamResultsService : IExamResultsService
    {
        private readonly IExamResultsRepository _repository;
        private readonly IMapper _mapper;

        public ExamResultsService(IExamResultsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddExamResultAsync(ExamResultListDTO examResultListDTO)
        {
            var results = await _repository.GetCurrentUserExamResultAsync(examResultListDTO.UserId, examResultListDTO.ExamId);

            //if(examResultListDTO.Points > results.points)
            //{

           // }

            var examResultToAdd = _mapper.Map<ExamResult>(examResultListDTO);
            await _repository.AddExamResultAsync(examResultToAdd);
            return examResultToAdd.ExamId;
        }

        public async Task<List<ExamResultListDTO>> GetCurrentUserExamResultAsync(int userId, int examId)
        {
            var results = await _repository.GetCurrentUserExamResultAsync(userId, examId);
            return _mapper.Map<List<ExamResultListDTO>>(results);
        }

        public async Task<UserExamResultListDTO> GetExamResultsAsync(int id)
        {
            var results = await _repository.GetExamResultsAsync(id);
            return _mapper.Map<UserExamResultListDTO>(results);
        }

    }
}
