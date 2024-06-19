namespace GameHub.Presentation.Endpoints.User;

public static class UserGroup
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var group = app.MapGroup("/user")
            .WithTags("User");

        group.MapGet("/{userName}", UserEndpoints.GetUserAsync);
        group.MapPut("/{userName}/reduceHealth", UserEndpoints.UpdateHealthAsync);

        return app;
    }
}
