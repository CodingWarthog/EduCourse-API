using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly educoursedbContext _context;

        public AuthRepository(educoursedbContext context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username);
        }
    }
}
