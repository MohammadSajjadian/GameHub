using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ModularMonolithicArch.WordGame.Api.Endpoints.Category;

public static class CategoryGroups
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/wordGame/category")
            .WithTags("WordGame Category");

        group.MapPost("/", CategoryEndpoints.CreateAsync);
        group.MapGet("/", CategoryEndpoints.GetCategoriesAsync);
        group.MapPut("/{userName}/decreaseHealth", CategoryEndpoints.DecreaseHealthAsync);

        return endpoints;
    }
}
