using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        int? ValidateToken(string token);
    }
}
