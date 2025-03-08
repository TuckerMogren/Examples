using Domain.DTOModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Repositories;
using Application.Commands;
using Application.Queries;
using MediatR;
using Data.Models;
using Okta;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Persistence.Authentication;
using Domain.Interfaces.Settings;

namespace ShopAPI.Authentication.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly OktaTokenService _okta;

    public AuthenticationController(IApplicationSettings applicationSettings, ILogger<AuthenticationController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _ = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));

        HttpClient httpclient = new HttpClient();

        _okta = new OktaTokenService(new Uri($"{applicationSettings.Tenants.Authority}/v1/token"),httpclient, logger);
    }


    [HttpPost("Token")]
    [AllowAnonymous]
    public async Task<ActionResult> Token([FromBody] AuthenticationDTO auth, CancellationToken cancellationToken = default)
    {

        try
        {
            _ = auth ?? throw new ArgumentNullException(nameof(auth));

            if(string.IsNullOrEmpty(auth.username))
            {
                throw new ArgumentException("Missing username");
            }

            _logger.LogInformation($"New login request {auth.username} from [{Request.HttpContext.Connection.RemoteIpAddress}]");
            if (string.IsNullOrEmpty(auth.password))
            {
                throw new ArgumentException("Missing password");
            }

            var response = await _okta.GetToken(auth.username, auth.password);

            return Ok(response);
        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to retrieve access token from okta", ex);
            return Unauthorized();
        }
    }

}

