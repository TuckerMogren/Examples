using Data.Models;
using Domain.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{


    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public TestController(ILogger<EmployeeController> logger, IMapper mapper, IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _config = configuration;
    }


    [HttpPost("TestConfiguration")]
    //public async Task<ActionResult>
    //TODO: Automapper, this will add an employee to the database. 
    public string  Config(CancellationToken cancellationToken = default)
    {
        var data = _config.GetConnectionString("Employee");

        return data ?? "NO DATA";
    }

}

