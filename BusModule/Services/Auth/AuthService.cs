using BusModule.DTOs;
using BusModule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusModule.Services.Auth
{
    public class AuthService(AppDbContext _context, IConfiguration configuration) : IAuthService
    {
        public async Task<TokenResponseDto?> LoginAsync(UserDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null)
            {
               return null;
            }
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, userDto.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Role))
                throw new Exception("User data is incomplete");
            var response = new TokenResponseDto
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateRefreshTokenAsync(user)
            };
            return response;
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

        public async Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto requestDto)
        {
            var user = await ValidateRefreshTokenAsync(requestDto.UserId, requestDto.RefreshToken);
            if (user == null)
            {
                return null; // Invalid or expired refresh token
            }
            var newAccessToken = CreateToken(user);
            var newRefreshToken = await GenerateRefreshTokenAsync(user);
            return new TokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }



        private async Task<User?> ValidateRefreshTokenAsync(int userId ,string refreshToken)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow || user.RefreshToken != refreshToken)
            {
                return null; // Invalid or expired refresh token
            }
            return user;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private async Task<string> GenerateRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Set expiry time for the refresh token
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return refreshToken;
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
