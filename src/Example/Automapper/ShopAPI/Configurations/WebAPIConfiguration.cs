using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using System.Net;
using NSwag.Generation.Processors.Security;

namespace ShopAPI.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class WebAPIConfiguration
	{

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1,0);
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                opt.ReportApiVersions = true;

            })
            .AddMvcCore();

            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "VVV";
                opt.SubstituteApiVersionInUrl = true;
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddOpenApiDocument(doc =>
            {
                doc.DocumentName = "v1";
                doc.ApiGroupNames = new[] { "1" };
                doc.Title = "Shop Web API";
                doc.OperationProcessors.Add(new OperationSecurityScopeProcessor("BearerToken"));
                doc.AddSecurity("BearerToken", new OpenApiSecurityScheme()
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Name = nameof(Authorization),
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Scheme = "Bearer",
                    Description = "BearerToken",
                });
            });

        }

    }
}

