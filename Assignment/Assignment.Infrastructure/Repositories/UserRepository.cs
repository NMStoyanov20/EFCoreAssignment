using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;
using DomainModel.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new()
        {
            new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateCreated = new DateTime(2023, 1, 10) },
            new User { UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DateCreated = new DateTime(2023, 2, 15) },
            new User { UserId = 3, FirstName = "Emily", LastName = "Brown", Email = "emily.brown@example.com", DateCreated = new DateTime(2023, 3, 20) }
        };

        public IEnumerable<User> GetAllUsers() => _users;

        public User GetUserById(int userId) => _users.FirstOrDefault(u => u.UserId == userId);
    }
}
