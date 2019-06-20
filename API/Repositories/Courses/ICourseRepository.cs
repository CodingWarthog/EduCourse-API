using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories.Courses
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseAsync(int id);
        Task<List<Course>> GetCoursesAsync();
        Task<User> GetMyCoursesAsync(int id);
        Task AddCourseAsync(Course course);
        Task DeleteCourse(int course_id);
        Task<bool> FindCourse(int course_id);
        Task<List<CourseEnrolment>> GetUserComplitedCoursesAsync(int userId);
        Task<List<Course>> GetRecommendedCourses(int idBest, int idSecondBest);
        Task<List<Course>> GetRecommendedCourses(int idBest);
    }
}
