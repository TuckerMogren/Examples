using System.Diagnostics;
using Domain.Interfaces.Settings;
using System.Diagnostics.CodeAnalysis;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    [DebuggerDisplay("{TenantName}|{Authority}")]
    public class TenantSettings : ITenantSettings
    {
        public string Authority { get;  }

        public string Audience { get;  }

        public bool IsDefaultScheme { get; }

        public string TenantName { get;  }

        public string AppSettingsSectionName => "Tenants";
    }
}

