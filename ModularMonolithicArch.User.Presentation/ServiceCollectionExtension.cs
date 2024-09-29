using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.UserModule;

namespace ModularMonolithicArch.User.Presentation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddUserModule(configuration);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(_Imports).Assembly));

        return services;
    }
}
