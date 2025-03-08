namespace Domain.Interfaces.Settings
{
    public interface ITenantSettings
    {
        string Authority { get; }
        string Audience { get; }
        bool IsDefaultScheme { get; }
        string TenantName { get; }
    }
}