using API.DTOs.CourseDTO;
using API.DTOs.ExamDTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Exams
{
    public interface IExamService
    {
        Task<List<ExamDTO>> GetExamsFromCourseAsync(int id);
        Task<CourseForExamsDTO> GetExamsFromCourseAngularAsync(int id);
        Task <List<ExamGetDTO>> GetDraftExamsCreatedByUserAsync(int id);
        Task<List<ExamGetDTO>> GetNormalExamsCreatedByUserAsync(int id);
        Task<ExamsDTO> GetQuestionsForExamAsync(int id);
        Task<List<QuestionsForExamsDTO>> GetQuestionsForExamMobAsync(int id);
        Task<ExamBlockDTO> GetBlockItemForExamAsync(int id);
        Task<CourseForAddDTO> GetCategoryOfExamAsync(int courseId);
        Task<UserForExamsDTO> GetExamsOfEnrolmentCoursesAsync(int id);
        Task<int> AddExamAsync(ExamsDTO examsDTO);
        Task DeleteExam(int exam_id);
        Task<bool> FindExam(int exam_id);
        Task<List<ExamGetDTO>> GetExamsCreatedByUserAsync(int id);
        Task<List<ExamDTO>> GetExamsABCDFromCourseAsync(int id);
    }
}
