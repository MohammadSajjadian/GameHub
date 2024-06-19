namespace GameHub.Api.Endpoints.Level;

public static class LevelGroup
{
    public static WebApplication AddLevelEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var group = app.MapGroup("/level");

        group.MapPost("/", LevelEndpoints.CreateLevel);

        return app;
    }
}
