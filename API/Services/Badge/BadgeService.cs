using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.BadgeDTO;
using API.Models;
using API.Repositories.Badge;
using AutoMapper;

namespace API.Services.Badge
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository _repository;
        private readonly IMapper _mapper;

        public BadgeService(IBadgeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddBadgeAsync(BadgeForAddDTO badgeDTO)
        {
            var category = _mapper.Map<Badges>(badgeDTO);
            await _repository.AddBadgeAsync(category);
            return category.Id;
        }

        public async Task<int> AssignBadge(AssignBadgeDTO assignBadgeDTO)
        {

            var assignment = _mapper.Map<BadgeAssignment>(assignBadgeDTO);

            //var badges = _repository.GetBadgeByCategoryAsync(assignment);

            await _repository.AssignBadge(assignment);
            return assignBadgeDTO.BadgeId;
        }

        public async Task DeleteBadgeAsync(int badgeId)
        {
            await _repository.DeleteBadgeAsync(badgeId);
        }

        public async Task<bool> FindBadgeAsync(int badgeId)
        {
            if (await _repository.FindBadgeAsync(badgeId) != false)
                return true;
            return false;
        }

        public async Task<BadgeForAddDTO> GetBadgeAsync(int id)
        {
            var badge = await _repository.GetBadgeAsync(id);
            return _mapper.Map<BadgeForAddDTO>(badge);
        }

        public async Task<List<BadgeForAddDTO>> GetBadgesAsync()
        {
            var badge = await _repository.GetBadgesAsync();
            return _mapper.Map<List<BadgeForAddDTO>>(badge);
        }

        public async Task<List<BadgeForAddDTO>> GetBadgesByCategoryAsync(int? categoryId)
        {
            var badge = await _repository.GetBadgeByCategoryAsync(categoryId);
            return _mapper.Map<List<BadgeForAddDTO>>(badge);
        }

        public async Task<UserForBadgeDTO> GetUserBadgesAsync(int id)
        {
            var badge = await _repository.GetUserBadgesAsync(id);
            return _mapper.Map<UserForBadgeDTO>(badge);
        }
    }
}
