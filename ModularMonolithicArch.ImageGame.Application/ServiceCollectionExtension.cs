using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.ImageGame.Application.Category.Mapper;
using ModularMonolithicArch.ImageGame.Application.Image.Mapper;
using ModularMonolithicArch.ImageGame.Application.Room.Mapper;

namespace ModularMonolithicArch.ImageGame.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

        services.AddScoped<ICategoryMapper, CategoryMapper>();
        services.AddScoped<IImageMapper, ImageMapper>();
        services.AddScoped<IRoomMapper, RoomMapper>();

        return services;
    }
}
