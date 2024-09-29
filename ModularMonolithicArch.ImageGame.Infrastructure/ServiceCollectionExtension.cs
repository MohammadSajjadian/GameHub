using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.ImageGame.Application.Category.Repository;
using ModularMonolithicArch.ImageGame.Application.Image.Repository;
using ModularMonolithicArch.ImageGame.Application.Room.Repository;
using ModularMonolithicArch.ImageGame.Infrastructure.Context;
using ModularMonolithicArch.ImageGame.Infrastructure.Services;

namespace ModularMonolithicArch.ImageGame.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContextPool<ImageGameContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DbGame"), opt => opt.EnableRetryOnFailure(3)));

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
