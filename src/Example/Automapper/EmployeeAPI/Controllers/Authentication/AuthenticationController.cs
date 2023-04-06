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

namespace EmployeeAPI.Authentication.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    [HttpPost("GetToken")]
    [AllowAnonymous]
    public async Task<ActionResult> GetToken([FromBody] AuthenticationDTO auth, CancellationToken cancellationToken = default)
    {
        return Ok(auth);
    }

}

