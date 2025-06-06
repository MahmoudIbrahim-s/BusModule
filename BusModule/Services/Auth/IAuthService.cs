using BusModule.DTOs;
using BusModule.Models;

namespace BusModule.Services.Auth
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserDto user);
        Task<string> LoginAsync(UserDto user);
    }
}
