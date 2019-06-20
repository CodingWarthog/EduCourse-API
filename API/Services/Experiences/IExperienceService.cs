using API.DTOs.CourseDTO;
using API.DTOs.ExperienceDTO;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Experiences
{
    public interface IExperienceService
    {
        Task<ExperienceForListDTO> GetExperienceAsync(int id);
        Task<ExperienceForListDTO> GetUserExperienceByCategoryAsync(int userId, int categoryId);
        Task<UserExperienceDTO> GetUserExperienceAsync(int id);
        Task<List<ExperienceForListDTO>> GetExperiencesAsync();
        Task<int> AddExperienceAsync(ExperienceForListDTO experienceForListDTO);
        Task<Badges> UpdateExperienceAsync(int categoryId, ExperienceForListDTO experienceForListDTO);
        Task DeleteExperienceAsync(int experienceId);
        Task<bool> FindExperience(int experienceId);
        bool ExperienceExists(int id);
    }
}
