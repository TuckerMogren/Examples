using System;
using System.Diagnostics.CodeAnalysis;
using Application.Commands;
using Application.Queries;
using Persistence.Repositories;
using MediatR;
using Domain.Interfaces.Repositories;

namespace ShopAPI.Configurations
{
	[ExcludeFromCodeCoverage]
	public static class RepositoryConfiguration
	{

		public static void ConfigureRepositories(this IServiceCollection services)
		{
			services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddTransient<IRequestHandler<SaveNewEmployeeCommand, Unit>, SaveNewEmployeeCommand.Handler>();
			services.AddTransient<IRequestHandler<GetEmployeeQuery, Unit>, GetEmployeeQuery.Handler>();
		}
	}

}

