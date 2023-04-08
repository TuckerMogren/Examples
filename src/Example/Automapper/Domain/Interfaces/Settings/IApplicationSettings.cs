using System;
namespace Domain.Interfaces.Settings
{
	public interface IApplicationSettings
	{
		ITenantSettings Tenants { get; set; }
		IConnectionStrings connectionStrings { get; set; }
		IOktaServiceToUserSettings oktaServiceToUserSettings { get; set; }
		IContentManagementSettings contentManagementSettings { get; set; }
	}
}

