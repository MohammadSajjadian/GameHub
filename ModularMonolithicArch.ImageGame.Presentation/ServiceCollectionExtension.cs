using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.ImageGame.Application;
using ModularMonolithicArch.ImageGame.Domain;
using ModularMonolithicArch.ImageGame.Infrastructure;

namespace ModularMonolithicArch.ImageGame.Presentation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureImageGameModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDomain();
        services.AddApplication();
        services.AddInfraStructure(configuration);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(_Imports).Assembly));

        return services;
    }
}
