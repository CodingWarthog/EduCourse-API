using API.DTOs.QuestionDTO;
using API.Models;
using API.Repositories.Questions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddQuestionAsync(QuestionDTO questionsDTO)
        {
            var question = _mapper.Map<Question>(questionsDTO);
            await _repository.AddQuestionAsync(question);
            return question.Id;
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _repository.DeleteQuestionAsync(id);
        }

        public async Task<bool> FindQuestionAsync(int id)
        {
            if (await _repository.FindQuestionAsync(id) != false)
                return true;
            return false;
        }

        public async Task<List<QuestionDTO>> GetQuestionsAsync()
        {
            var questions = await _repository.GetQuestionsAsync();
            return _mapper.Map<List<QuestionDTO>>(questions);
        }
    }
}
