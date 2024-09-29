using Microsoft.AspNetCore.Routing;
using ModularMonolithicArch.ImageGame.Api.Endpoints.Category;
using ModularMonolithicArch.ImageGame.Api.Endpoints.Image;
using ModularMonolithicArch.ImageGame.Api.Endpoints.Room;

namespace ModularMonolithicArch.ImageGame.Api;

public static class ServiceCollectionExtension
{
    public static IEndpointRouteBuilder ConfigureImageGameModuleEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapRoomEndpoints();
        app.MapImageEndpoints();
        app.MapCategoryEndpoints();

        return app;
    }
}
