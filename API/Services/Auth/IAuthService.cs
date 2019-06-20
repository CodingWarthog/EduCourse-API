using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Auth
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User> LoginAsync(string username, string password);
        Task<bool> UserExistsAsync(string username);
    }
}
