using API.DTOs.CourseDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Courses
{
    public interface ICoursesService
    {
        Task<CourseForAddDTO> GetCourseAsync(int id);
        Task<List<CourseForAddDTO>> GetCoursesAsync(int userId);
        Task<int> AddCourseAsync(CourseForAddDTO courseForAddDTO);
        Task<UserCoursesDTO> GetMyCoursesAsync(int id);
        Task DeleteCourse(int course_id);
        Task<bool> FindCourse(int course_id);
        Task<List<CourseForAddDTO>> RecommendCoursesAsync(int userId);
    }
}
