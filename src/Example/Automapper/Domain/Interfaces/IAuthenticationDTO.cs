using System;
namespace Domain.Interfaces
{
	public interface IAuthenticationDTO
	{
		public string? username { get; set; }
		public string? password { get; set; }
	}
}

