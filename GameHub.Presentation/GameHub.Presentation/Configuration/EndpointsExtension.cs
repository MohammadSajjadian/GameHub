using GameHub.Presentation.Endpoints.Account;
using GameHub.Presentation.Endpoints.ImageGame.Category;
using GameHub.Presentation.Endpoints.ImageGame.Image;
using GameHub.Presentation.Endpoints.ImageGame.Room;
using GameHub.Presentation.Endpoints.User;
using GameHub.Presentation.Endpoints.WordGame.Category;
using GameHub.Presentation.Endpoints.WordGame.Level;

namespace GameHub.Presentation.Configuration;

public static class EndpointsExtension
{
    public static IEndpointRouteBuilder ConfigureEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapLevelEndpoints();
        app.MapCategoryEndpoints();
        app.MapUserEndpoints();
        app.MapRoomEndpoints();
        app.MapImageGameCategoryEndpoints();
        app.MapImageGameImageEndpoints();
        app.MapLogOutEndpoint();

        return app;
    }
}
