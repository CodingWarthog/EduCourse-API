using API.DTOs.ExperienceDTO;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Experiences
{
    public interface IExperienceRepository
    {
        Task<Experience> GetExperienceAsync(int id);
        Task<Experience> GetUserExperienceByCategoryAsync(int userId, int categoryId);
        Task<User> GetUserExperienceAsync(int id);
        Task<List<Experience>> GetExperiencesAsync();
        Task AddExperienceAsync(Experience experience);
        Task UpdateExperienceAsync(Experience experience);
        Task DeleteExperienceAsync(int experienceId);
        Task<bool> FindExperience(int experienceId);
        Experience GetExperienceFromBase(int id);
        Task<Course> GetCategoryOfExamAsync(int courseId);
        bool ExperienceExists(int id);
       
    }
}
