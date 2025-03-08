using System.Diagnostics.CodeAnalysis;
using Serilog;


namespace ShopAPI.Configurations
{
    [ExcludeFromCodeCoverage]
	public static class MonitorConfiguration
	{
		public static void ConfigureLogging(this IServiceCollection services)
		{
			services.AddLogging(cfg => cfg.AddSerilog());
		}

	}
}

