using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services;

public class AuthenticationService
    (IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Validate that user doesn't exist

        if (userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User with given Email already exists");
        }

        // Create user (generate unique id) persist to repository

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        // Upload to repository

        userRepository.Add(user);

        // Generate token

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate that user exists

        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given Email doesn't exist");
        }

        // Validate that password is correct
        
        if (user.Password != password)
        {
            throw new Exception("Password is incorrect");
        }

        // Generate token
        
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}