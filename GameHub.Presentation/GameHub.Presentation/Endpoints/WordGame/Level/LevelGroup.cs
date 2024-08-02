namespace GameHub.Presentation.Endpoints.WordGame.Level;

public static class LevelGroup
{
    public static IEndpointRouteBuilder MapLevelEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/wordGame/level")
            .WithTags("wordGame Level");

        group.MapPost("/", LevelEndpoints.CreateAsync).RequireAuthorization(opt => opt.RequireRole("Admin"));
        group.MapGet("/{id}", LevelEndpoints.GetAsync);
        group.MapGet("/{id}/category/{categoryId}/next", LevelEndpoints.GetNextLevelAsync);

        return endpoints;
    }
}
