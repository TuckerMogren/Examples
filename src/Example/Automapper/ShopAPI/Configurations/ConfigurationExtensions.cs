using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using Domain.Interfaces.Settings;
using ShopAPI.Settings;

namespace ShopAPI.Configurations
{
	[ExcludeFromCodeCoverage]
	public static class ConfigurationExtensions
	{
		public static IApplicationSettings AsApplicationSettings(this IConfiguration config)
		{
			if(config is null)
			{
				throw new ArgumentNullException(nameof(config));
			}

			var applicationSettings = new ApplicationSettings();

			var test = applicationSettings;

			config.Bind(applicationSettings);
            config.Bind(applicationSettings.Tenants);

            return applicationSettings;
		}
	}
}

