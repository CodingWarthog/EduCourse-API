using API.Models;
using API.Repositories.CourseEnrolments;
using System.Threading.Tasks;

namespace API.Repositories.CourseEnrolments
{
    public class CourseEnrolmentsRepository : ICourseEnrolmentsRepository
    {
        private readonly educoursedbContext _context ;

        public CourseEnrolmentsRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task EnrolCourseAsync(CourseEnrolment courseEnrolment)
        {
            _context.CourseEnrolment.Add(courseEnrolment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnrolment(int user_id, int course_id)
        {
            var enrolment = await _context.CourseEnrolment.FindAsync(user_id, course_id);

            _context.Remove(enrolment);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> FindCourse(int course_id)
        {

            if (await _context.Course.FindAsync(course_id) != null)
                return true;
            return false;
        }

        public async Task<bool> FindCourseEnrolment(int user_id, int course_id)
        {
            if (await _context.CourseEnrolment.FindAsync(user_id, course_id) != null)
                return true;
            return false;
        }

        public async Task<bool> FindUser(int user_id)
        {
            if (await _context.User.FindAsync(user_id) != null)
                return true;
            return false;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
