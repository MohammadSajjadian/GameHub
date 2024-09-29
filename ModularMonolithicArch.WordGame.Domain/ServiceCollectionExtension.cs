using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.WordGame.Domain.Repository;
using ModularMonolithicArch.WordGame.Domain.Services;

namespace ModularMonolithicArch.WordGame.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<IWordGameService, WordGameService>();
        services.AddScoped<IWordService, WordService>();
        services.AddScoped<ILetterService, LetterService>();

        return services;
    }
}
