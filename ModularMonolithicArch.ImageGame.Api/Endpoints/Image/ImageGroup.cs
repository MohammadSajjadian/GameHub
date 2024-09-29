using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ModularMonolithicArch.ImageGame.Api.Endpoints.Image
{
    public static class ImageGroup
    {
        public static IEndpointRouteBuilder MapImageEndpoints(this IEndpointRouteBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);

            var group = app.MapGroup("/imageGame/image")
                .WithTags("ImageGame Image");

            group.MapPost("/", ImageEndpoints.CreateAsync);
            group.MapPost("/upload/{imageId}", ImageEndpoints.UploadImageAsync);
            group.MapGet("/random/{categoryId}/{boardSize}/{seed}", ImageEndpoints.GetRandomAsync);

            return app;
        }
    }
}
