using API.DTOs.CourseDTO;
using API.DTOs.UserDTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Users
{
    public interface IUserService
    {
        Task<int> UpdateUserInfoAsync(int id, UserInfoUpdateDTO userInfoDTO);
        Task<int> UpdateRoleAsync(int id, RoleUpdateDTO roleUpdateDTO);
        Task<UserInfoDTO> GetUserInfoAsync(int id);
        Task<UserInfoDTO> GetUserByUsername(string username);
        Task<List<UserInfoDTO>> GetUsersAsync();
        Task<List<CourseForAddDTO>> GetUserCourses(int id);
        bool UserExists(int id);
        Task<bool> UserExistsAsync(string username);

        Task<List<CourseList>> GetQuantityOfCoursesByCategory();
        Task<UserInfoDTO> GetQuantityOfExamsByCategory(string username);
        Task<StatiticsOverall> GetOverallStatistics();
        Task<Mark> GetMarksStatistics(int userId);
        Task<PersonalStatistics> GetPersonalStatistics(int userId);
    }
}
