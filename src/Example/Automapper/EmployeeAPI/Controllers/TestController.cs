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
    private readonly IConfiguration _config;

    public TestController(ILogger<EmployeeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _config = configuration;
    }


    [HttpPost("TestConfiguration")]
    public string Config()
    {
        
        var data = _config.GetConnectionString("Employee");

        _logger.LogDebug($"Getting Connection String for Employee DB: {data}");

        return data ?? "NO DATA";
    }

}

