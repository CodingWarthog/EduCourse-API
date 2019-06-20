using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Exams
{
    public interface IExamRepository
    {
        Task<Course> GetExamsFromCourseAsync(int id);
        Task<User> GetExamsCreatedByUserAsync(int id);
        Task<Exam> GetQuestionsForExamAsync(int id);
        Task<Exam> GetBlocksForExamAsync(int id);
        Task<Course> GetCategoryOfExamAsync(int courseId);
        Task<User> GetExamsOfEnrolmentCoursesAsync(int id);
        Task AddExamAsync(Exam exam);
        Task DeleteExam(int exam_id);
        Task<bool> FindExam(int exam_id);
    }
}
