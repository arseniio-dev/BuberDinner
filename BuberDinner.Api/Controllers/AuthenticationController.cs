using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        return Ok();
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok();
    }
}