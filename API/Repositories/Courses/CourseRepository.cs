using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly educoursedbContext _context;

        public CourseRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int course_id)
        {
            var course = await _context.Course.FindAsync(course_id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindCourse(int course_id)
        {
            if (await _context.Course.FindAsync(course_id) != null)
                return true;
            return false;
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Course.Where(course => course.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<User> GetMyCoursesAsync(int id)
        {
            return await _context.User.Include(user => user.Course).Where(course => course.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CourseEnrolment>> GetUserComplitedCoursesAsync(int userId)
        {
            var userCourses = await _context.CourseEnrolment
                                    .Include(c => c.Course)
                                    .Where(ce => ce.UserId == userId)
                                    .ToListAsync();
            return userCourses;

        }

        public async Task<List<Course>> GetRecommendedCourses(int idBest, int idSecondBest)
        {
            var userCourses = await _context.Course
                                    .Where(c => c.CategoryId == idBest || c.CategoryId == idSecondBest)
                                    .ToListAsync();
            return userCourses;
        }
        public async Task<List<Course>> GetRecommendedCourses(int idBest)
        {
            var userCourses = await _context.Course
                                    .Where(c => c.CategoryId == idBest)
                                    .ToListAsync();
            return userCourses;
        }
    }
}
