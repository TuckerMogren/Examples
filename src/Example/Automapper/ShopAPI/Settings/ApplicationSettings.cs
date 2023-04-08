using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Settings;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    public class ApplicationSettings : IApplicationSettings
    {
        public ITenantSettings Tenants { get; set; } = new TenantSettings();
        public IOktaServiceToUserSettings oktaServiceToUserSettings { get; set; } = new OktaServiceToUserSettings();
        public IConnectionStrings connectionStrings { get; set; } = new ConnectionStringsSettings();
        public IContentManagementSettings contentManagementSettings { get; set; } = new ContentManagementSettings();
    }
}

