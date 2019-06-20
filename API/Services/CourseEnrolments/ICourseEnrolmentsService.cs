using API.DTOs.CourseEnrolmentDTO;
using System;
using System.Threading.Tasks;


namespace API.Services.CourseEnrolments
{
    public interface ICourseEnrolmentsService
    {
        Task<DateTime> EnrolCourseAsync(EnrolDTO enrolDTO);
        Task<bool> DeleteEnrolment(int user_id, int course_id);
        Task<bool> FindCourse(int course_id);
        Task<bool> FindCourseEnrolment(int user_id, int course_id);
        Task<bool> FindUser(int user_id);
        Task<bool> SaveAll();
    }
}
