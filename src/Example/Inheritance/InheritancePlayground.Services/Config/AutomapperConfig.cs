using AutoMapper;

namespace InheritancePlayground.Services.Config;

public static class AutomapperConfig
{
    public static MapperConfiguration ConfigureAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
        });

        config.AssertConfigurationIsValid();

        return config;
    }
}