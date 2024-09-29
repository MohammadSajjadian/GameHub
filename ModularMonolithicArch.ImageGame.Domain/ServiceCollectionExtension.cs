using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.ImageGame.Domain.Repository;
using ModularMonolithicArch.ImageGame.Domain.Services;

namespace ModularMonolithicArch.ImageGame.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<IImageGameService, ImageGameService>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
