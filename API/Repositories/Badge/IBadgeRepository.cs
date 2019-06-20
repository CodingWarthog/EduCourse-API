using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories.Badge
{
    public interface IBadgeRepository
    {
        Task<Badges> GetBadgeAsync(int id); // zwraca pojedyncza odznakę
        Task<List<Badges>> GetBadgeByCategoryAsync(int? categoryId); // zwraca odznaki po ich kategorii
        Task<User> GetUserBadgesAsync(int id); // zwraca odznaki jakie otrzymał konkretny użytkownik
        Task<List<Badges>> GetBadgesAsync(); // zwraca wszystkie odznaki
        Task AddBadgeAsync(Badges badges); // dodaje nową odznakę
        Task DeleteBadgeAsync(int badgeId); // usuwa istniejącą odznakę
        Task<bool> FindBadgeAsync (int badgeId); // wyszkuje odznake po id
        Task AssignBadge (BadgeAssignment badgeAssignment); // przydziela odznakę
        Task<BadgeAssignment> GetAssignment(int userId, int badgeId);
 
    }
}
