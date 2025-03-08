using System;
namespace Domain.Interfaces.Settings
{
    public interface IConnectionStrings : ICustomSettings
    {
        string Database { get; set; }
    }
}

