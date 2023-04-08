using System.Diagnostics;
using Domain.Interfaces.Settings;
using System.Diagnostics.CodeAnalysis;

namespace ShopAPI.Settings
{
    [ExcludeFromCodeCoverage]
    [DebuggerDisplay("{TenantName}|{Authority}")]
    public class TenantSettings : ITenantSettings
    {
        public string Authority { get; set; }

        public string Audience { get; set; }

        public bool IsDefaultScheme { get; set; }

        public string TenantName { get; set; }

    }
}

