using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.DTO;
using UserTestingApp.Extensions;

namespace UserTestingApp.Controllers;

[ApiController]
[Route("api/tests")]
[Authorize]
public class TestController : Controller
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllTests()
    {
        var userId = HttpContext.GetUserId();

        var result = await _testService.GetAllTestsAsync(userId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTestById(Guid id)
    {
        var result = await _testService.GetTestAsync(id);

        return Ok(result);
    }

    [HttpPost("answer")]
    [Authorize]
    public async Task<IActionResult> UploadAnswer(UploadAnswerDTO dto)
    {
        var userId = HttpContext.GetUserId();

        var result = await _testService.CheckTestAnswerAsync(userId, dto);
        return Ok(result);
    }
}
