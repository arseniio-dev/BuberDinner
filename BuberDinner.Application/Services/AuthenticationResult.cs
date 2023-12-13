using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services;

public record AuthenticationResult(
    User user,
    string Token);