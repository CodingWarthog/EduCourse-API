using API.DTOs.BadgeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Badge
{
    public interface IBadgeService
    {
        Task<BadgeForAddDTO> GetBadgeAsync(int id);
        Task<List<BadgeForAddDTO>> GetBadgesAsync();
        Task<List<BadgeForAddDTO>> GetBadgesByCategoryAsync(int? categoryId);
        Task<UserForBadgeDTO> GetUserBadgesAsync(int id);
        Task<int> AddBadgeAsync(BadgeForAddDTO badgeDTO);
        Task DeleteBadgeAsync(int badgeId);
        Task<bool> FindBadgeAsync(int badgeId);
        Task<int> AssignBadge(AssignBadgeDTO assignBadgeDTO);
    }
}
