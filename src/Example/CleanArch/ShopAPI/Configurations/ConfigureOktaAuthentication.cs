using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain.Interfaces.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ShopAPI.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureOktaAuthentication
	{
		public static void AddOktaAuthentication(this IServiceCollection services, IApplicationSettings appSettings)
		{
			if(appSettings is null)
			{
				throw new ArgumentNullException(nameof(appSettings));

			}

			var tenants = appSettings.Tenants;


			string defaultScheme = tenants.TenantName;

			var defaultTenant = tenants.TenantName;

			if(defaultTenant != null)
			{
				defaultScheme = defaultTenant;
			}

			AuthenticationBuilder builder = services.AddAuthentication(defaultScheme);

			builder.AddJwtBearer(tenants.TenantName, options =>
			{
				options.Authority = tenants.Authority;
				options.Audience = tenants.Audience;
				options.RequireHttpsMetadata = false;
			});

			string authenticationSchemes = tenants.TenantName;

			services.AddAuthorization(options => {
				options.DefaultPolicy = new AuthorizationPolicyBuilder(authenticationSchemes)
					.RequireAuthenticatedUser()
					.Build();

				});

		}
	}
}

