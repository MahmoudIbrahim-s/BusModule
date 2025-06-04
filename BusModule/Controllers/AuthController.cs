using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusModule.Models;
using BusModule.Services.Auth;

namespace BusModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                return BadRequest("Email, password, and role are required.");
            var result = await _authService.RegisterAsync(email, password, role);
            if (!result)
                return Conflict("User already exists.");
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest("Email and password are required.");
            var token = await _authService.LoginAsync(email, password);
            if (token == null)
                return Unauthorized("Invalid email or password.");
            return Ok(new { Token = token });
        }
    }
}
