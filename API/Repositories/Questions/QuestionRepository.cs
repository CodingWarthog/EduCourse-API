using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly educoursedbContext _context;

        public QuestionRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var exam = await _context.Question.FindAsync(id);
            _context.Question.Remove(exam);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> FindQuestionAsync(int id)
        {
            if (await _context.Question.FindAsync(id) != null)
                return true;
            return false;
        }
        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await _context.Question.ToListAsync();
        }
    }
}
