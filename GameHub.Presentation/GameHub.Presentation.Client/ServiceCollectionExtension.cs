using Blazored.LocalStorage;
using GameHub.Presentation.Client.Services;
using GameHub.Presentation.Client.Services.WordGame;

namespace GameHub.Presentation.Client;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationClient(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddHttpClient("Client", client => client.BaseAddress = new Uri("https://localhost:7154/"));
        services.AddBlazoredLocalStorage();

        services.AddScoped<ModalService>();
        services.AddScoped<WordService>();
        services.AddScoped<HealthService>();

        return services;
    }
}
