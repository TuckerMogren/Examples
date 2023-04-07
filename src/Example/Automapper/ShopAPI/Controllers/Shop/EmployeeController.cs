using Domain.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Repositories;
using Application.Commands;
using Application.Queries;
using MediatR;
using Data.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace ShopAPI.Shop.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{


    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repo;
    private readonly IMediator _mediatr;
    private readonly IConfiguration _config;

    public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IEmployeeRepository repo, IMediator mediator, IConfiguration configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _mediatr = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }


    [HttpPost("AddEmployee")]
    public async Task<ActionResult> AddEmployee([FromBody] EmployeeDTO emp, CancellationToken cancellationToken = default)
    {
        

        if(emp == null)
        {
            _logger.LogCritical("EmployeeDTO is Null");
            return BadRequest();
        }

        _logger.LogInformation("The full name of the employee being added is: " + emp.FullName);
        var data = _config.GetConnectionString("Data");


        var savecmd = new SaveNewEmployeeCommand(emp);
        await _mediatr.Send(savecmd, cancellationToken);
       
        return Ok(emp);
    }

    [HttpGet("GetEmployee")]
    [Authorize]
    public async Task<IActionResult> GetEmployee([FromQuery][Required] int? id, [FromQuery] EmployeeDTO emp, CancellationToken cancellationToken)
    {

        if (id == null || emp == null)
        {
            return BadRequest();
        }

        //await _repo.GetEmployeeByID(id);

        //Map from employeeDTO to employee 
        var query = new GetEmployeeQuery(emp,id);
        await _mediatr.Send(query, cancellationToken);

        return Ok(query);
    }

}

