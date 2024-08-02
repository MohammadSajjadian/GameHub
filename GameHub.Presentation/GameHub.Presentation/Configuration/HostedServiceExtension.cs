using GameHub.Infra.BackroundTasks.WordGame;

namespace GameHub.Presentation.Configuration;

public static class HostedServiceExtension
{
    public static IServiceCollection ConfigureHostedServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddHostedService<HealthBackgroundService>();

        return services;
    }
}
