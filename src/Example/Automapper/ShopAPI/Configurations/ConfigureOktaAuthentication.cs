using System;
using System.Diagnostics.CodeAnalysis;
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


			string defaultScheme = tenants.LastOrDefault().TenantName;

			var defaultTenant = tenants.FirstOrDefault(x => x.IsDefaultScheme);

			if(defaultTenant != null)
			{
				defaultScheme = defaultTenant.TenantName;
			}

			AuthenticationBuilder builder = services.AddAuthentication(defaultScheme);

			foreach(var tenant in tenants)
			{
				builder.AddJwtBearer(tenant.TenantName, options =>
				{
					options.Authority = tenant.Authority;
					options.Audience = tenant.Audience;
					options.RequireHttpsMetadata = false;
				});
			}

			string[] authenticationSchemes = tenants.Select(x => x.TenantName).ToArray();

			services.AddAuthorization(options => {
				options.DefaultPolicy = new AuthorizationPolicyBuilder(authenticationSchemes)
					.RequireAuthenticatedUser()
					.Build();

				});

		}
	}
}

