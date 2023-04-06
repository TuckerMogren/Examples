using System;
using Domain.Interfaces;
namespace Domain.DTOModels
{
	public class AuthenticationDTO : IAuthenticationDTO
	{
        public string? username { get; set; }
        public string? password { get; set; }
    }
}

