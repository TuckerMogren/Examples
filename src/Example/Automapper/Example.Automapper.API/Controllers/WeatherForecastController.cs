using Microsoft.AspNetCore.Mvc;

namespace Example.Automapper.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpPost("AddEmployee")]
    public async Task<IActionResult> AddEmployee()
    {

        return Ok();
    }

}

