using BuberDinner.Application.Services;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this._authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest authenticationRequest)
    {
        var authenticationResult = this._authenticationService.Register(
            authenticationRequest.FirstName,
            authenticationRequest.LastName,
            authenticationRequest.Email,
            authenticationRequest.Password);

        var authenticationResponse = new AuthenticationResponse(
            authenticationResult.Id,
            authenticationResult.FirstName,
            authenticationResult.LastName,
            authenticationResult.Email,
            authenticationResult.Token);

        return Ok(authenticationResponse);
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authenticationResult = this._authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);
        
        var authenticationResponse = new AuthenticationResponse(
            authenticationResult.Id,
            authenticationResult.FirstName,
            authenticationResult.LastName,
            authenticationResult.Email,
            authenticationResult.Token);
        
        return Ok(authenticationResponse);
    }
}