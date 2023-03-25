using System.Diagnostics.CodeAnalysis;
using Serilog;


namespace EmployeeAPI.Configurations
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

