namespace GameHub.Presentation.Endpoints.WordGame.Category;

public static class CategoryGroups
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/wordGame/category")
            .WithTags("WordGame Category");

        group.MapPost("/", CategoryEndpoints.CreateAsync);
        group.MapGet("/", CategoryEndpoints.GetCategoriesAsync);

        return endpoints;
    }
}
