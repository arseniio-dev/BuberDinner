using BuberDinner.Application.Services;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest authenticationRequest)
    {
        var authenticationResult = authenticationService.Register(
            authenticationRequest.FirstName,
            authenticationRequest.LastName,
            authenticationRequest.Email,
            authenticationRequest.Password);

        var authenticationResponse = new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Email,
            authenticationResult.Token);

        return Ok(authenticationResponse);
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authenticationResult = authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);

        var authenticationResponse = new AuthenticationResponse(
            authenticationResult.user.Id,
            authenticationResult.user.FirstName,
            authenticationResult.user.LastName,
            authenticationResult.user.Email,
            authenticationResult.Token);

        return Ok(authenticationResponse);
    }
}