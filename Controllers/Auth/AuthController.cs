using Finances.DTOs.Auth;
using Finances.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Controllers.Auth;


[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        var response = await authService.LoginAsync(dto);

        return Ok(response);
    }
}
