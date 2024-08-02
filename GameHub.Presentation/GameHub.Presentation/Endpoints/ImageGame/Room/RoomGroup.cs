namespace GameHub.Presentation.Endpoints.ImageGame.Room;

public static class RoomGroup
{
    public static IEndpointRouteBuilder MapRoomEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var group = app.MapGroup("/imageGame/room")
            .WithTags("ImageGame Room")
            .RequireAuthorization();

        group.MapPost("/", RoomEndpoints.CreateAsync);
        group.MapGet("/all", RoomEndpoints.GetAllAsync);
        group.MapGet("/{id}", RoomEndpoints.GetAsync);
        group.MapDelete("/{id}", RoomEndpoints.DeleteAsync);
        group.MapPut("/scores", RoomEndpoints.UpdateWinnerAsync);

        return app;
    }
}
