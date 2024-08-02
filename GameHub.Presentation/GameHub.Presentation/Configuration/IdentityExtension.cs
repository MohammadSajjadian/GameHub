using GameHub.Domain.Entities;
using GameHub.Infra.Context;
using GameHub.Presentation.Components.Pages.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GameHub.Presentation.Configuration;

public static class IdentityExtension
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddCascadingAuthenticationState();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GameContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

        return services;
    }

    public static WebApplication ConfigureIdentityMiddlewares(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
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
