using BuberDinner.Application.Common.Interfaces;

namespace BuberDinner.Application.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user exists

        // Create user (generate unique id)

        // Generate token

        var userId = Guid.NewGuid();

        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }
}