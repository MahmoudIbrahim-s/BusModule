using BusModule.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusModule.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = await authService.RegisterAsync(userDto);
            if (user == null)
            {
                return BadRequest("User registration failed.");
            }
            return Ok(new { user.Id, user.Email, user.Role });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var token = await authService.LoginAsync(userDto);
            if (token == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok(new { Token = token });
        }
        [Authorize]
        [HttpGet]
        public IActionResult AuthonticatedOnlyEndpoint()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok("You are authenticated.");
            }

            return Unauthorized("You are not authenticated.");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnlyEndpoint()
        {
            if (User.IsInRole("Admin"))
            {
                return Ok("You are an admin.");
            }
            return Forbid("You are not authorized to access this endpoint.");
        }
        [Authorize(Roles = "Student")]
        [HttpGet("student")]
        public IActionResult StudentOnlyEndpoint()
        {
            if (User.IsInRole("Student"))
            {
                return Ok("You are a student.");
            }
            return Forbid("You are not authorized to access this endpoint.");
        }
        [Authorize(Roles = "Admin,Student")]
        [HttpGet("admin-or-student")]
        public IActionResult AdminOrStudentEndpoint()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Student"))
            {
                return Ok("You are either an admin or a student.");
            }
            return Forbid("You are not authorized to access this endpoint.");
        }
    }
}
