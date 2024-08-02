using FluentValidation;
using GameHub.Application.ImageGame.Image.Mapper;
using GameHub.Application.ImageGame.Room.Mapper;
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
        services.AddScoped<WordGame.Category.Mapper.ICategoryMapper, WordGame.Category.Mapper.CategoryMapper>();
        services.AddScoped<ILeveMapper, LeveMapper>();
        services.AddScoped<IRoomMapper, RoomMapper>();
        services.AddScoped<ImageGame.Category.Mapper.ICategoryMapper, ImageGame.Category.Mapper.CategoryMapper>();
        services.AddScoped<IImageMapper, ImageMapper>();

        return services;
    }
}
