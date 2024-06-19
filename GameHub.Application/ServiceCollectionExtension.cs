using FluentValidation;
using GameHub.Application.Category.Mapper;
using GameHub.Application.User.Mapper;
using GameHub.Application.WordGame.Level.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace GameHub.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddScoped<IWordGameLeveMapper, WordGameLeveMapper>();

        return services;
    }
}
