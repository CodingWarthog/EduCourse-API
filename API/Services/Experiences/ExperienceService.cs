using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.CourseDTO;
using API.DTOs.ExperienceDTO;
using API.Models;
using API.Repositories.Badge;
using API.Repositories.Experiences;
using AutoMapper;

namespace API.Services.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _repository;
        private readonly IBadgeRepository _badgeRepository;
        private readonly IMapper _mapper;
        private static bool assignmentBadge = false;
        private static int obtainedBadgeId;
        private static Badges obtainedBadge;

        public ExperienceService(IExperienceRepository repository, 
            IBadgeRepository badgeRepository,
            IMapper mapper)
        {
            _repository = repository;
            _badgeRepository = badgeRepository;
            _mapper = mapper;
        }

        public async Task<int> AddExperienceAsync(ExperienceForListDTO experienceForListDTO)
        {
            var experience = _mapper.Map<Experience>(experienceForListDTO);
            await _repository.AddExperienceAsync(experience);
            return experience.Id;
        }

        public async Task DeleteExperienceAsync(int experienceId)
        {
            await _repository.DeleteExperienceAsync(experienceId);
        }

        public bool ExperienceExists(int id)
        {
            return _repository.ExperienceExists(id);
        }

        public async Task<bool> FindExperience(int experienceId)
        {
            if (await _repository.FindExperience(experienceId) != false)
                return true;
            return false;
        }

        public async Task<ExperienceForListDTO> GetExperienceAsync(int id)
        {
            var experience = await _repository.GetExperienceAsync(id);
            return _mapper.Map<ExperienceForListDTO>(experience);
        }

        public async Task<List<ExperienceForListDTO>> GetExperiencesAsync()
        {
            var experience = await _repository.GetExperiencesAsync();
            return _mapper.Map<List<ExperienceForListDTO>>(experience);
        }

        public async Task<UserExperienceDTO> GetUserExperienceAsync(int id)
        {
            var experience = await _repository.GetUserExperienceAsync(id);
            return _mapper.Map<UserExperienceDTO>(experience);
        }

        public async Task<ExperienceForListDTO> GetUserExperienceByCategoryAsync(int userId, int categoryId)
        {
            var experience = await _repository.GetUserExperienceByCategoryAsync(userId, categoryId);
            return _mapper.Map<ExperienceForListDTO>(experience);
        }

        public async Task<Badges> UpdateExperienceAsync(int courseId, ExperienceForListDTO experienceForListDTO)
        {

            var category = await _repository.GetCategoryOfExamAsync(courseId);
            int categoryID = category.CategoryId;

            var experience_current = await _repository.GetUserExperienceByCategoryAsync(experienceForListDTO.UserId, categoryID);

            if (experience_current == null)
            {
                experienceForListDTO.CategoryId = categoryID;
                var exp_to_post = _mapper.Map<Experience>(experienceForListDTO);
                await _repository.AddExperienceAsync(exp_to_post);
            }
            else
            {
                var experience = _repository.GetExperienceFromBase(experience_current.Id);
                var exp_from_base = experience.ExperiencePoints;

                experienceForListDTO.CategoryId = categoryID;

                var exp_to_add = exp_from_base + experienceForListDTO.ExperiencePoints;
                experienceForListDTO.ExperiencePoints = exp_to_add;
                experience.CategoryId = categoryID;

                var exp = _mapper.Map(experienceForListDTO, experience);
                await _repository.UpdateExperienceAsync(exp);

                // przydzielanie odznaki
                
               
                var badges_by_category = await _badgeRepository.GetBadgeByCategoryAsync(exp.CategoryId);
                foreach (var badge in badges_by_category)
                {
                   var assign = await _badgeRepository.GetAssignment(exp.UserId, badge.Id);
                    if (assign == null) 
                    {
                        if (exp.ExperiencePoints >= badge.ExperiencePoints)
                        {
                            assignmentBadge = true;
                            BadgeAssignment assignment = new BadgeAssignment();
                            assignment.BadgeId = badge.Id;
                            assignment.UserId = exp.UserId;

                            obtainedBadgeId = badge.Id;
                            
                            await _badgeRepository.AssignBadge(assignment);
                        }
                        
                       
                        
                    }
                }
                if(assignmentBadge == true)
                {

                    obtainedBadge = await _badgeRepository.GetBadgeAsync(obtainedBadgeId);
                }

            }
            return obtainedBadge;
        }
    }
}
