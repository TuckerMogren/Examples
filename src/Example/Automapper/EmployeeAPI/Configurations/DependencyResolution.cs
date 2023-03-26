using System;
using System.Diagnostics.CodeAnalysis;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Configurations
{
	[ExcludeFromCodeCoverage]
	public static class DependencyResolution
	{
		public static void ConfigureData(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EmployeeContext>(opts =>
				opts.UseSqlServer(configuration.GetConnectionString("Data"))
			);

			var test = configuration.GetConnectionString("Data");

			Console.WriteLine(test);

		}
	}
}

