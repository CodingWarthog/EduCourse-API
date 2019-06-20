using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task DeleteQuestionAsync(int id);
        Task<bool> FindQuestionAsync(int id);
        Task<List<Question>> GetQuestionsAsync();
    }
}
