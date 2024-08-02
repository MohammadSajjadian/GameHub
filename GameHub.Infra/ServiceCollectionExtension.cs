using IGCR = GameHub.Application.ImageGame.Category.Repository;
using WGCR = GameHub.Application.WordGame.Category.Repository;
using GameHub.Application.ImageGame.Image.Repository;
using GameHub.Application.ImageGame.Room.Repository;
using GameHub.Application.User.Repository;
using GameHub.Application.WordGame.Level.Repository;
using GameHub.Infra.Context;
using GameHub.Infra.Services.ImageGame.Image;
using GameHub.Infra.Services.ImageGame.Room;
using GameHub.Infra.Services.User;
using GameHub.Infra.Services.WordGame.Level;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IGC = GameHub.Infra.Services.ImageGame.Category;
using WGC = GameHub.Infra.Services.WordGame.Category;

namespace GameHub.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContextPool<GameContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DbGame"),
        opt => opt.EnableRetryOnFailure(3)));

        services.AddScoped<IUserService, UserService>();

        // WordGame services
        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<WGCR.ICategoryService, WGC.CategoryService>();

        // ImageGame services
        services.AddScoped<IGCR.ICategoryService, IGC.CategoryService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
