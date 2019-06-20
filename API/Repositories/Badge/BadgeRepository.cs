using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Badge
{
    public class BadgeRepository : IBadgeRepository
    {
        private readonly educoursedbContext _context;

        public BadgeRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task AddBadgeAsync(Badges badges)
        {
            _context.Badges.Add(badges);
            await _context.SaveChangesAsync();
        }

        public async Task AssignBadge(BadgeAssignment badgeAssignment)
        {
            
            _context.BadgeAssignment.Add(badgeAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBadgeAsync(int badgeId)
        {
            var badge = await _context.Badges.FindAsync(badgeId);
            _context.Badges.Remove(badge);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindBadgeAsync(int badgeId)
        {
            if (await _context.Badges.FindAsync(badgeId) != null)
                return true;
            return false;
        }

        public async Task<BadgeAssignment> GetAssignment(int userId, int badgeId)
        {
           
            return await _context.BadgeAssignment.Where(badge => badge.UserId == userId && badge.BadgeId == badgeId).FirstOrDefaultAsync();
        }

        public async Task<Badges> GetBadgeAsync(int id)
        {
            return await _context.Badges.Where(badge => badge.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Badges>> GetBadgeByCategoryAsync(int? categoryId)
        {
            return await _context.Badges.Where(badge => badge.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Badges>> GetBadgesAsync()
        {
            return await _context.Badges.ToListAsync();
        }

        public async Task<User> GetUserBadgesAsync(int id)
        {
            return await _context.User.Where(user => user.Id == id)
                .Include(badgeToUser => badgeToUser.BadgeAssignment)
                .ThenInclude(badge => badge.Badge).Where(badgeToUser => badgeToUser.Id == badgeToUser.Id).FirstOrDefaultAsync();
        }
    }
}
