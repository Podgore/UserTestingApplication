using Microsoft.AspNetCore.Mvc;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.DTO;

namespace UserTestingApp.Controllers;

[ApiController]
[Route("api/auth")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> Auth(UserDTO userDTO)
    {
        var result = await _userService.Authorization(userDTO);
        return Ok(result);
    }
}