using GameHub.Domain.Entities;
using GameHub.Infra.Context;
using Microsoft.AspNetCore.Identity;

namespace GameHub.Presentation.Configuration;

public static class IdentityConfigurationsExtension
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GameContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        return services;
    }

    public static async Task InitializeRole(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        string[] roles = ["Admin"];

        foreach (string role in roles)
        {
            var identityRole = new IdentityRole(role);
            await roleManager.CreateAsync(identityRole);
        }

        var user = new ApplicationUser
        {
            Email = "admin@gmail.com",
            UserName = "admin@gmail.com",
            EmailConfirmed = true,
        };

        if (await userManager.FindByEmailAsync(user.Email) is null)
            await userManager.CreateAsync(user, "pP_0987");

        if (!await userManager.IsInRoleAsync(user, "Admin"))
            await userManager.AddToRoleAsync(user, "Admin");
    }
}
