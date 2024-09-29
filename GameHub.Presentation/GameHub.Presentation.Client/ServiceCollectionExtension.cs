using Blazored.LocalStorage;
using GameHub.Domain;
using GameHub.Presentation.Client.Services;

namespace GameHub.Presentation.Client;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationClient(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDomain();
        services.AddHttpClient("Client", client => client.BaseAddress = new Uri("https://localhost:7154/"));
        services.AddBlazoredLocalStorage();

        services.AddScoped<ModalService>();

        return services;
    }
}
