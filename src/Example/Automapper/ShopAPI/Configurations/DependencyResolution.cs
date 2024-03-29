﻿using System;
using System.Diagnostics.CodeAnalysis;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Configurations
{
	[ExcludeFromCodeCoverage]
	public static class DependencyResolution
	{
		public static void ConfigureData(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EmployeeContext>(opts =>
				opts.UseSqlServer(configuration.GetConnectionString("Database"))
			);


		}
	}
}

