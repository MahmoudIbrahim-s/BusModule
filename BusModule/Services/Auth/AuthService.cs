using BusModule.Models;
using BusModule.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusModule.Services.Auth
{
    public class AuthService : IAuthService
    {
        // This class is responsible for user authentication and registration.
        // It interacts with the database to manage user credentials and roles.
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<bool> RegisterAsync(string email, string password, string role)
        {
            var encryptedEmail = EncryptionHelper.Encrypt(email.ToLower());
            var hashedPassword = PasswordHasher.HashPassword(password);

            if (await _context.Users.AnyAsync(u => u.EncryptedEmail == encryptedEmail))
                return false;

            var user = new User
            {
                EncryptedEmail = encryptedEmail,
                HashedPassword = hashedPassword,
                Role = role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> LoginAsync(string email, string password)
        {
            var encryptedEmail = EncryptionHelper.Encrypt(email.ToLower());
            var hashedPassword = PasswordHasher.HashPassword(password);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.EncryptedEmail == encryptedEmail && u.HashedPassword == hashedPassword);

            if (user == null) return null;
            // Generate a JWT token for the user
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
    }
    
}
