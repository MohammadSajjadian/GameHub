using Microsoft.AspNetCore.Components.Authorization;

namespace GameHub.Presentation.Client.Configuration;

public static class IdentityConfigurationsExtension
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddAuthorizationCore();
        services.AddCascadingAuthenticationState();
        services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

        return services;
    }

}
