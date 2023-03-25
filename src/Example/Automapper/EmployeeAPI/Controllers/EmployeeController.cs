using Data.Models;
using Domain.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{


    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;

    public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper
    }


    [HttpPost("AddEmployee")]
    //public async Task<ActionResult>
    //TODO: Automapper, this will add an employee to the database. 
    public async Task<ActionResult> AddEmployee([FromBody] EmployeeDto emp, CancellationToken cancellationToken = default)
    {
        

        if(emp == null)
        {
            return BadRequest();
        }


        var data = _mapper.Map<Employee>(emp);

        //Do something with the data

        return Ok(emp);
    }

    [HttpGet("GetEmployee")]
    //public async Task<ActionResult>
    //TODO: Automapper, this will add an employee to the database. 
    public async Task<ActionResult> GetEmployee([FromBody] EmployeeDto emp, CancellationToken cancellationToken)
    {


        if (emp == null)
        {
            return BadRequest();
        }



        var data = _mapper.Map<EmployeeDto>(emp);

        return Ok(emp);
    }

}

