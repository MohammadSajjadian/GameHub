using ModularMonolithicArch.Web.Components;

namespace ModularMonolithicArch.Web.Configuration;

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
           .AddAdditionalAssemblies(
            typeof(Client._Imports).Assembly,
            typeof(WordGame.Presentation._Imports).Assembly,
            typeof(User.Presentation._Imports).Assembly,
            typeof(ImageGame.Presentation._Imports).Assembly,
            typeof(TypeGame.Presentation._Imports).Assembly);

        return app;
    }
}
