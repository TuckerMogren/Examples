using System;
using System.Diagnostics;
using Domain.Interfaces.Settings;
using System.Diagnostics.CodeAnalysis;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    public class OktaServiceToUserSettings : IOktaServiceToUserSettings
    {
        public string ServiceName { get; set; }
        public string ApplicationClientId { get; set; }
        public string ApplicationSecret { get; set; }
        public string TokenURL { get; set; }

        public string AppSettingsSectionName => "OktaServiceToUser";
    }
}

