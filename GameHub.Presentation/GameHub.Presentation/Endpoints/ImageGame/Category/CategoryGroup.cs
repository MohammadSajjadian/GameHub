namespace GameHub.Presentation.Endpoints.ImageGame.Category;

public static class CategoryGroup
{
    public static IEndpointRouteBuilder MapImageGameCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var group = app.MapGroup("/imageGame/category")
            .WithTags("ImageGame Category");

        group.MapPost("/", CategoryEndpoints.CreateAsync);
        group.MapGet("/", CategoryEndpoints.GetAllAsync);

        return app;
    }
}
