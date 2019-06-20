using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User> LoginAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
