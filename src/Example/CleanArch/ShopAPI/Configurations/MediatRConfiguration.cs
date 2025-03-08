using System.Diagnostics.CodeAnalysis;
using MediatR;
using Persistence.Repositories;
using Application.Commands;
using Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Domain.DTOModels;

namespace ShopAPI.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class MediatRConfiguration
	{
        
        public static void ConfigureMediatR(this IServiceCollection services)
		{
            services.AddMediatR(
                typeof(Program).Assembly,
                typeof(EmployeeRepository).Assembly,
                typeof(SaveNewEmployeeCommand).Assembly,
                typeof(GetEmployeeQuery).Assembly);

            
        }

    }
}

