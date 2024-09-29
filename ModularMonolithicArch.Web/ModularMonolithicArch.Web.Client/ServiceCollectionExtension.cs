using ModularMonolithicArch.ImageGame.Presentation;
using ModularMonolithicArch.User.Presentation;
using ModularMonolithicArch.WordGame.Presentation;

namespace ModularMonolithicArch.Web.Client;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureSharedWebClient(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddHttpClient("Client", client => client.BaseAddress = new Uri("https://localhost:7197"));
        services.ConfigureImageGameModule(configuration);
        services.ConfigureUserModule(configuration);
        services.ConfigureWordGameModule(configuration);
        services.ConfigureShared();

        return services;
    }
}
