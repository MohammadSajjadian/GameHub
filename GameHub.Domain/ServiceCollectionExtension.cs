using GameHub.Domain.Repository.ImageGame;
using GameHub.Domain.Repository.WordGame;
using GameHub.Domain.Services.ImageGame;
using GameHub.Domain.Services.WordGame;
using Microsoft.Extensions.DependencyInjection;

namespace GameHub.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // Image Game
        services.AddScoped<IImageGameService, ImageGameService>();
        services.AddScoped<IImageService, ImageService>();

        // Word Game
        services.AddScoped<IWordGameService, WordGameService>();
        services.AddScoped<IWordService, WordService>();
        services.AddScoped<ILetterService, LetterService>();

        return services;
    }
}
