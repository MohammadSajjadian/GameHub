namespace GameHub.Presentation.Endpoints.Category;

public static class CategoryGroups
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/category")
            .WithTags("Category");

        group.MapPost("/", CategoryEndpoints.CreateAsync);
        group.MapGet("/", CategoryEndpoints.GetCategoriesAsync);

        return endpoints;
    }
}
