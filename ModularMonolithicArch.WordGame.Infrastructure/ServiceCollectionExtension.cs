using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.WordGame.Application.Category.Repository;
using ModularMonolithicArch.WordGame.Application.Level.Repository;
using ModularMonolithicArch.WordGame.Infrastructure.BackroundTasks;
using ModularMonolithicArch.WordGame.Infrastructure.Context;
using ModularMonolithicArch.WordGame.Infrastructure.Services;

namespace ModularMonolithicArch.WordGame.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContextPool<WordGameContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DbGame"),
        opt => opt.EnableRetryOnFailure(3)));

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

        services.AddScoped<ILevelService, LevelService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddHostedService<HealthBackgroundService>();

        return services;
    }
}
