using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Repositories.ExamResults
{
    public interface IExamResultsRepository
    {
        Task AddExamResultAsync(ExamResult examResult);
        //Task<ExamResult> GetQuestionResultAsync(int id);
        Task<User> GetExamResultsAsync(int id);
        Task<List<ExamResult>> GetCurrentUserExamResultAsync(int userId, int examId);
    }
}
