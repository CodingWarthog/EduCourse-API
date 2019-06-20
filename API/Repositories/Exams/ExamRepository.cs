using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace API.Services.Exams
{
    public class ExamRepository : IExamRepository
    {
        private readonly educoursedbContext _context;

        public ExamRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetExamsFromCourseAsync(int id)
        {
            return await _context.Course.Include(e => e.Exam).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetExamsCreatedByUserAsync(int id)
        {
            return await _context.User.Include(user => user.Course).ThenInclude(course => course.Exam).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Exam> GetQuestionsForExamAsync(int id)
        {
            return await _context.Exam.Include(exam => exam.Question).Where(exam => exam.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetExamsOfEnrolmentCoursesAsync(int id)
        {
            return await _context.User
                        .Include(user => user.CourseEnrolment)
                        .ThenInclude(courseEnrolment => courseEnrolment.Course)
                        .ThenInclude(course => course.Exam)
                        .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddExamAsync(Exam exam)
        {
            _context.Exam.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int exam_id)
        {
            var exam = await _context.Exam.FindAsync(exam_id);
            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> FindExam(int exam_id)
        {
            if (await _context.Exam.FindAsync(exam_id) != null)
                return true;
            return false;
        }

        public async Task<Exam> GetBlocksForExamAsync(int id)
        {
            return await _context.Exam.Include(exam => exam.BlockItem).Where(exam => exam.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> GetCategoryOfExamAsync(int courseId)
        {
            return await _context.Course.Where(exam => exam.Id == courseId).FirstOrDefaultAsync();
        }
    }
}
