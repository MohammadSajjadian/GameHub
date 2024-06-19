namespace GameHub.Presentation.Endpoints.WordGame.Level;

public static class WordGameLevelGroup
{
    public static IEndpointRouteBuilder MapLevelEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/level")
            .WithTags("Level");

        group.MapPost("/", WordGameLevelEndpoints.CreateAsync).RequireAuthorization(opt => opt.RequireRole("Admin"));
        group.MapGet("/{id}", WordGameLevelEndpoints.GetAsync);
        group.MapGet("/{id}/category/{categoryId}/next", WordGameLevelEndpoints.GetNextLevelAsync);

        return endpoints;
    }
}
