using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Repositories.Users
{
    public interface IUserRepository
    {
        Task UpdateUserInfoAsync(User user);
        Task UpdateRoleAsync(User user);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserInfoAsync(int id);
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserCourses(int id);
        bool UserExists(int id);
        User GetUserFromBase(int id);
        Task<bool> UserExistsAsync(string username);

        // statistics bar overall
        Task<int> GetNumberOfAvailableCourses();
        Task<int> GetNumberOfAvaialableExams();
        Task<int> GetNumberOfFlashcardSets();
        Task<int> GetNumberOfAvailableMaterials();
        Task<int> GetNumberOfCategory();
        Task<int> GetNumberOfBadges();
        Task<int> GetNumberOfRegisteredUsers();

        // statistics column personal
        Task<int> GetNumberOfEnrolmentCourses(int userId);
        Task<int> GetNumberOfEnrolmentExams();
        Task<int> GetNumberOfAddedCourses(int userId);
        Task<int> GetNumberOfAddedMaterials(int userId);
        Task<User> GetNumberOfAssignedBadges(int userId);

        // statistics exams and course by category
        Task<List<Course>> GetNumberOfCoursesByCategory(int categoryId);
        Task<List<Category>> GetCategories();
        Task<int> GetNumberOfExamsByCategory(int categoryId);
        // Marks
        Task<int> GetNumberNegativeMark(int userId);
        Task<int> GetNumberPositiveMark(int userId);
    }
}
