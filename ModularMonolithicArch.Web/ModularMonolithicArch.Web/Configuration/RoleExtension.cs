using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;

namespace ModularMonolithicArch.Web.Configuration;

public static class RoleExtension
{
    public static async Task<WebApplication> ConfigureRole(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            await IdentityExtension.InitializeRole(roleManager, userManager);
        }

        return app;
    }
}
