using Microsoft.AspNetCore.Mvc;
using Gym.Infrastructure.Authentication.Identity;

namespace Gym.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] UserRequest request)
    {
        var user = IdentityService.Login(request.Username, request.Password);

        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        var token = IdentityService.GenerateToken(user);
        
        return Ok(new { user = user.Username, token = token });
    }
}

public class UserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}