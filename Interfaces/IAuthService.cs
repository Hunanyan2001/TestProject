using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IAuthService
    {
        Task<User> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
        Task LogoutAsync();
    }
}
