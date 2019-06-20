using API.Models;
using System.Threading.Tasks;


namespace API.Repositories.CourseEnrolments
{
    public interface ICourseEnrolmentsRepository
    {
        Task EnrolCourseAsync(CourseEnrolment courseEnrolment);
        Task DeleteEnrolment(int user_id, int course_id);
        Task<bool> FindUser(int user_id);
        Task<bool> FindCourse(int course_id);
        Task<bool> FindCourseEnrolment(int user_id, int course_id);
        Task<bool> SaveAll();
    }
}
