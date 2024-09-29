using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ModularMonolithicArch.ImageGame.Api.Endpoints.Category;

public static class CategoryGroup
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var group = app.MapGroup("/imageGame/category")
            .WithTags("ImageGame Category");

        group.MapPost("/", CategoryEndpoints.CreateAsync);
        group.MapGet("/", CategoryEndpoints.GetAllAsync);

        return app;
    }
}
