using BusModule.DTOs;
using BusModule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusModule.Services.Auth
{
    public class AuthService(AppDbContext _context, IConfiguration configuration) : IAuthService
    {
        public async Task<string> LoginAsync(UserDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null)
            {
               return "User not found.";
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, userDto.Password) != PasswordVerificationResult.Success)
            {
                return "Invalid password.";
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Role))
                throw new Exception("User data is incomplete");
            return CreateToken(user);
        }

        public async Task<User> RegisterAsync(UserDto userDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
            {
                return null; // User already exists
            }

            var newuser = new User
            {
                Email = userDto.Email,
                Role = userDto.Role
            };

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(newuser, userDto.Password);
            newuser.Password = hashedPassword;

            _context.Users.Add(newuser);
            await _context.SaveChangesAsync();

            return newuser;
        }
        private string CreateToken(User user)
        {
            // Token generation logic would go here, such as creating a JWT token
            var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email), 
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role) 
                };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!)
                );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"), // Fixed spelling error
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claim,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor); // Fixed missing return statement
        }
    }
}
