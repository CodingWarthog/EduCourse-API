using API.DTOs.QuestionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Questions
{
    public interface IQuestionService
    {
        Task<int> AddQuestionAsync(QuestionDTO questionDTO);
        Task DeleteQuestionAsync(int id);
        Task<bool> FindQuestionAsync(int id);
        Task<List<QuestionDTO>> GetQuestionsAsync();
    }
}
