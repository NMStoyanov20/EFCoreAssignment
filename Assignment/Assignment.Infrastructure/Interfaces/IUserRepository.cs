using Assignment.DomainModel.Models;
using DomainModel.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
    }
}
