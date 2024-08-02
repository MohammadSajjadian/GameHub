using GameHub.Presentation.Components;

namespace GameHub.Presentation.Configuration;

public static class BlazorExtension
{
    public static IServiceCollection ConfigureBlazor(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        return services;
    }

    public static IEndpointRouteBuilder ConfigureBlazorMiddleWares(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        return app;
    }
}
