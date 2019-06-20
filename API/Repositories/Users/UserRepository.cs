using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly educoursedbContext _context;

        public UserRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task UpdateUserInfoAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public User GetUserFromBase(int id)
        {
            var userToBase = _context.User.Find(id);
            return userToBase;
        }

        public async Task<User> GetUserCourses(int id)
        {

            return await _context.User.Where(a => a.Id == id)
                        .Include(user => user.CourseEnrolment)
                        .ThenInclude(courseEnrolment => courseEnrolment.Course).Where(user => user.Id == user.Id).FirstOrDefaultAsync();
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public async Task<User> GetUserInfoAsync(int id)
        {
            return await _context.User.SingleOrDefaultAsync(user => user.Id == id);//.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.User.SingleOrDefaultAsync(user => user.Id == id);//.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();//.FirstOrDefaultAsync();
        }

        public async Task UpdateRoleAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.User.SingleOrDefaultAsync(user => user.Username == username);//.FirstOrDefaultAsync();
        }
        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username);
        }

        public async Task<int> GetNumberOfAvailableCourses()
        {
            return await _context.Course.CountAsync();
        }

        public async Task<int> GetNumberOfAvaialableExams()
        {
            return await _context.Exam.CountAsync();
        }

        public async Task<int> GetNumberOfFlashcardSets()
        {
            return await _context.FlashcardSet.CountAsync();
        }

        public async Task<int> GetNumberOfAvailableMaterials()
        {
            return await _context.Asset.CountAsync();
        }

        public async Task<int> GetNumberOfCategory()
        {
            return await _context.Category.CountAsync();
        }

        public async Task<int> GetNumberOfRegisteredUsers()
        {
            return await _context.User.CountAsync();
        }

        public async Task<int> GetNumberOfEnrolmentCourses(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetNumberOfEnrolmentExams()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> GetNumberOfAddedCourses(int userId)
        {
            return await _context.Course.Where(course => course.UserId == userId).CountAsync();
        }


        public async Task<List<Course>> GetNumberOfCoursesByCategory(int categoryId)
        {
            return await _context.Course.Where(course => course.CategoryId == categoryId).ToListAsync();
        }

        public async Task<int> GetNumberOfExamsByCategory(int categoryId)
        {
            return await _context.Exam.CountAsync();
        }

        public async Task<int> GetNumberNegativeMark(int userId)
        {
            return await _context.ExamResult.Where(mark => mark.UserId == userId && mark.Mark == "Niezaliczone").CountAsync();
        }

        public async Task<int> GetNumberPositiveMark(int userId)
        {
            return await _context.ExamResult.Where(mark => mark.UserId == userId && mark.Mark == "Bardzo dobry"
            || mark.Mark == "Dobry" || mark.Mark == "Dostateczny").CountAsync();
        }

        public async Task<User> GetNumberOfAssignedBadges(int userId)
        {
            return await _context.User.Where(user => user.Id == userId)
                .Include(badgeToUser => badgeToUser.BadgeAssignment)
                .ThenInclude(badge => badge.Badge).Where(badgeToUser => badgeToUser.Id == badgeToUser.Id).FirstOrDefaultAsync();
        }

        public async Task<int> GetNumberOfBadges()
        {
            return await _context.Badges.CountAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<int> GetNumberOfAddedMaterials(int userId)
        {
            return await _context.Asset.Where(asset => asset.UserId == userId).CountAsync();
        }
    }
}
