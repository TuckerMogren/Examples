using System.Diagnostics.CodeAnalysis;

namespace EmployeeAPI.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerConfiguration
	{
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();

        }

    }
}

