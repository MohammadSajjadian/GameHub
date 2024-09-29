using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;
using ModularMonolithicArch.UserModule.Shared.Persistence;

namespace ModularMonolithicArch.UserModule;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContextPool<UserContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DbGame"), opt => opt.EnableRetryOnFailure(3)));

        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<UserContext>();

        return services;
    }
}
