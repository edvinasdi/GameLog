using GameLog.Infrastructure.Startup;

namespace GameLog.Public.Host.Capabilities;

public static class StartupInjection
{
    public static IServiceCollection ConfigureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.RegisterDatabase(configuration);

        return services;
    }
}