using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Settings;

namespace ShopAPI.Configurations
{
	[ExcludeFromCodeCoverage]
	public static class SettingConfiguration
	{
		public static void ConfigureApplicationSettings(this IServiceCollection services, IApplicationSettings applicationSettings)
		{
			services.AddSingleton<IApplicationSettings>(applicationSettings);
		}
	}
}

