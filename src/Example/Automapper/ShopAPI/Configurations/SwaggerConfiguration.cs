using System.Diagnostics.CodeAnalysis;

namespace ShopAPI.Configurations
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

