using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Settings;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    public class ApplicationSettings : IApplicationSettings
    {
        public ITenantSettings[] Tenants { get; set; } = Array.Empty<TenantSettings>();
        public IOktaServiceToUserSettings[] oktaServiceToUserSettings { get; set; } = Array.Empty<OktaServiceToUserSettings>();
        public IConnectionStrings connectionStrings { get; set; } = new ConnectionStringsSettings();
        public IContentManagementSettings contentManagementSettings { get; set; } = new ContentManagementSettings();
    }
}

