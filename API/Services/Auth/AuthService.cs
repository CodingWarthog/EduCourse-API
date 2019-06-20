using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories.Auth;

namespace API.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _repository.LoginAsync(username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            Console.WriteLine(user);
            return user;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (user.Role == null || user.Role == "")
            {
                user.Role = "Student";
            }

            await _repository.RegisterAsync(user, password);

            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            if (await _repository.UserExistsAsync(username))
                return true;

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
