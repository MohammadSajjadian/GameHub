using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.Shared.Modal;

namespace ModularMonolithicArch.ImageGame.Presentation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureShared(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        services.AddScoped<ModalService>();
        services.AddBlazoredLocalStorage();

        return services;
    }
}
