using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.DTOs.UserDTO;
using API.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers.Users
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string Value = "Podane konto nie istnieje";
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInformation(int id, UserInfoUpdateDTO userInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userInfoDTO == null)
            {
                throw new ArgumentNullException(nameof(userInfoDTO));
            }
            userInfoDTO.Username = userInfoDTO.Username.ToLower();

            if (await _service.UserExistsAsync(userInfoDTO.Username))
                return BadRequest("Podana nazwa użytkownika jest zajęta");
            try
            {
                var result = await _service.UpdateUserInfoAsync(id, userInfoDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_service.UserExists(id)))
                {
                    return NotFound(Value);
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        [HttpPut("role/{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, RoleUpdateDTO roleUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (roleUpdateDTO == null)
            {
                throw new ArgumentNullException(nameof(roleUpdateDTO));
            }

            try
            {
                var result = await _service.UpdateRoleAsync(id, roleUpdateDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_service.UserExists(id)))
                {
                    return NotFound(Value);
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInformation(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserInfoAsync(id);
            if (result == null)
            {
                return NotFound(Value);
            }

            return Ok(result);
        }
        [HttpGet("information/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserByUsername(username);
            if (result == null)
            {
                return NotFound(Value);
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUsersAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("courses/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetUserCourses(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("overall_statistics")]
        public async Task<IActionResult> GetOverall()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetOverallStatistics();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("mark_statistics/{userId}")]
        public async Task<IActionResult> GetMarkStatistics(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetMarksStatistics(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("courseByCategory")]
        public async Task<IActionResult> GetMarkStatistics()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetQuantityOfCoursesByCategory();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("personal_statistics/{userId}")]
        public async Task<IActionResult> GetPersonalStatistics(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetPersonalStatistics(userId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {      
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);           

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);                

                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //return StatusCode(500, "Internal server error :( ");
                return BadRequest(ex);
            }
        }
    }
}