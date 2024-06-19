using GameHub.Application.Category.Repository;
using GameHub.Application.User.Repository;
using GameHub.Application.WordGame.Level.Repository;
using GameHub.Infra.Context;
using GameHub.Infra.Services.Category;
using GameHub.Infra.Services.User;
using GameHub.Infra.Services.WordGame.Level;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameHub.Infra;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContextPool<GameContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DbGame"),
        opt => opt.EnableRetryOnFailure(3)));

        services.AddScoped<IWordGameLevelService, WordGameLevelService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
