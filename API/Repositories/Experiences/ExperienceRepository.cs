using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Experiences
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly educoursedbContext _context;

        public ExperienceRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddExperienceAsync(Experience experience)
        {
            _context.Experience.Add(experience);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExperienceAsync(int experienceId)
        {
            var experience = await _context.Experience.FindAsync(experienceId);
            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
        }

        public bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.Id == id);
        }

        public async Task<bool> FindExperience(int experienceId)
        {
            if (await _context.Experience.FindAsync(experienceId) != null)
                return true;
            return false;
        }

        public async Task<Course> GetCategoryOfExamAsync(int courseId)
        {
            return await _context.Course.Where(exam => exam.Id == courseId).FirstOrDefaultAsync();
        }

        public async Task<Experience> GetExperienceAsync(int id)
        {

            return await _context.Experience.Where(experience => experience.Id == id).FirstOrDefaultAsync();
        }

        public Experience GetExperienceFromBase(int id)
        {
            var experience = _context.Experience.Find(id);
            return experience;
        }

        public async Task<List<Experience>> GetExperiencesAsync()
        {
            return await _context.Experience.ToListAsync();
        }

        public async Task<User> GetUserExperienceAsync(int id)
        {
            return await _context.User.Include(user => user.Experience).Where(experience => experience.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Experience> GetUserExperienceByCategoryAsync(int userId, int categoryId)
        {
            return await _context.Experience.Where(exp => exp.UserId == userId && exp.CategoryId == categoryId).FirstOrDefaultAsync();
        }

        public async Task UpdateExperienceAsync(Experience experience)
        {
            _context.Entry(experience).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
