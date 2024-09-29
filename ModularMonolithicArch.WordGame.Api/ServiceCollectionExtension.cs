using Microsoft.AspNetCore.Routing;
using ModularMonolithicArch.WordGame.Api.Endpoints.Category;
using ModularMonolithicArch.WordGame.Api.Endpoints.Level;

namespace ModularMonolithicArch.WordGame.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IEndpointRouteBuilder ConfigureWordGameModuleEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapCategoryEndpoints();
        app.MapLevelEndpoints();

        return app;
    }
}
