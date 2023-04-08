namespace Domain.Interfaces.Settings
{
    public interface IOktaServiceToUserSettings : ICustomSettings
    {
        string ServiceName { get; set; }
        string ApplicationClientId { get; set; }
        string ApplicationSecret { get; set; }
        string TokenURL { get; set; }
    }
}