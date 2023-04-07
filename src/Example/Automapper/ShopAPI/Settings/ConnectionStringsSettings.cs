using System;
using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Settings;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    public class ConnectionStringsSettings : IConnectionStrings
    {
        public string Database { get; set; }

        public string AppSettingsSectionName => "ConnectionStrings";
    }
}

