using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
    }
}
