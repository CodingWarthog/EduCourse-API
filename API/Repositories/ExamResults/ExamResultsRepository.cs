using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repositories.ExamResults
{
    public class ExamResultsRepository : IExamResultsRepository
    {
        private readonly educoursedbContext _context ;

        public ExamResultsRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddExamResultAsync(ExamResult examResult)
        {
            _context.ExamResult.Add(examResult);
            await _context.SaveChangesAsync();

        }

        public async Task<List<ExamResult>> GetCurrentUserExamResultAsync(int userId, int examId)
        {
            return await _context.ExamResult.Where(result => result.UserId == userId && result.ExamId == examId).ToListAsync();
        }

        public async Task<User> GetExamResultsAsync(int id)
        {
            return await _context.User.Include(user => user.ExamResult).Where(user => user.Id == id).FirstOrDefaultAsync();
        }

        //public async Task<ExamResult> GetQuestionResultAsync(int id)
        //{
        //   return await _context.ExamResult.Include(user => user.QuestionResult).Where(user => user.Id == id).FirstOrDefaultAsync();
        //}
    }
}
