using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new List<User>();
    
    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(user => user.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return Users.SingleOrDefault(user => user.Id == id);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}