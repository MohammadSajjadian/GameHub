namespace GameHub.Presentation.Endpoints.ImageGame.Image
{
    public static class ImageGroup
    {
        public static IEndpointRouteBuilder MapImageGameImageEndpoints(this IEndpointRouteBuilder app)
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
