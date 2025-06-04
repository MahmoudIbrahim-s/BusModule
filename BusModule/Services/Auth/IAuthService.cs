namespace BusModule.Services.Auth
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(string email, string password, string role);
       public Task<string> LoginAsync(string email, string password);
    }
}
