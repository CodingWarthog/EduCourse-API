using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.UserDTO.Auth
{
    public class UserForRegisterDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Hasło musi zawierać od 4 do 10 znaków")]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

    }
}
