using Domain.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Repositories;
using Application.Commands;
using Application.Queries;
using MediatR;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{


    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _repo;
    private readonly IMediator _mediatr;

    public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IEmployeeRepository repo, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _mediatr = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost("AddEmployee")]
    public async Task<ActionResult> AddEmployee([FromBody] EmployeeDto emp, CancellationToken cancellationToken = default)
    {
        

        if(emp == null)
        {
            return BadRequest();
        }


        var savecmd = new SaveNewEmployeeCommand(emp);
        await _mediatr.Send(savecmd, cancellationToken);
        

        //Do something with the data

        return Ok(emp);
    }

    [HttpGet("GetEmployee")]
    public async Task<ActionResult> GetEmployee([FromQuery] int? id, CancellationToken cancellationToken)
    {


        if (id == null)
        {
            return BadRequest();
        }
        var query = new GetEmployeeQuery(id);
        await _mediatr.Send(query, cancellationToken);

        return Ok(query);
    }

}

