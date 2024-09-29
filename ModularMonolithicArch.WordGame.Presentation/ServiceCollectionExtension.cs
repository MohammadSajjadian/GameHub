using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.WordGame.Application;
using ModularMonolithicArch.WordGame.Domain;
using ModularMonolithicArch.WordGame.Infrastructure;

namespace ModularMonolithicArch.WordGame.Presentation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureWordGameModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDomain();
        services.AddApplication();
        services.AddInfraStructure(configuration);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(_Imports).Assembly));

        return services;
    }
}
