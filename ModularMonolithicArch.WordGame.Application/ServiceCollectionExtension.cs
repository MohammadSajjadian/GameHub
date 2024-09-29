using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.WordGame.Application.Category.Mapper;
using ModularMonolithicArch.WordGame.Application.Level.Mapper;

namespace ModularMonolithicArch.WordGame.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddScoped<ILeveMapper, LeveMapper>();

        return services;
    }
}
