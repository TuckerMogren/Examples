using System;
namespace Domain.Interfaces.Settings
{
    public interface IConnectionStrings
    {
        string CAU { get; set; }
        string ServiceBusConStr { get; set; }
        string AzAppConfiguration { get; set; }
    }
}

