using API.DTOs.ExamResultDTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.ExamResults
{
    public interface IExamResultsService
    {
        Task<int> AddExamResultAsync(ExamResultListDTO examResultListDTO);
        //Task<ExamResultListDTO> GetQuestionResultAsync(int id);
        Task<UserExamResultListDTO> GetExamResultsAsync(int id);
        Task<List<ExamResultListDTO>> GetCurrentUserExamResultAsync(int userId, int examId);
    }
}
