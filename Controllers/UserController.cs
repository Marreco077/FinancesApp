using Finances.DTOs;
using Finances.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> Create(CreateUserDto dto)
    {
        var user = await userService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = user.Id },
            user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponseDto>> Update(Guid id, UpdateUserDto dto)
    {
        var user = await userService.UpdateAsync(id, dto);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}