using FluentValidation;
using GameHub.Application.ImageGame.Image.Dto;
using GameHub.Application.ImageGame.Image.Repository;

namespace GameHub.Presentation.Endpoints.ImageGame.Image
{
    public static class ImageEndpoints
    {
        public static async Task<IResult> CreateAsync(ImageDto imageDto, IValidator<ImageDto> validator, IImageService service, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(imageDto);
            if (!validationResult.IsValid)
                return Results.ValidationProblem(validationResult.ToDictionary());

            int result = await service.CreateAsync(imageDto, cancellationToken);
            return result > 0 ? Results.Ok(result)
                : Results.UnprocessableEntity("Failed to add Image");
        }

        public static async Task<IResult> UploadImageAsync(int imageId, HttpRequest httpRequest, IValidator<IFormFile> validator, IImageService service, CancellationToken cancellationToken)
        {
            var file = httpRequest.Form.Files[0];

            var validationResult = validator.Validate(file);
            if (!validationResult.IsValid)
                Results.ValidationProblem(validationResult.ToDictionary());

            int result = await service.UploadImageAsync(imageId, file, cancellationToken);
            return result > 0 ? Results.Ok("Image uploaded successfuly.")
                : Results.UnprocessableEntity("Failed to upload Image");
        }

        public static async Task<List<ImageDto>?> GetRandomAsync(int categoryId, int boardSize, int seed, IImageService service, CancellationToken cancellationToken)
            => await service.GetRandomAsync(categoryId, boardSize, seed, cancellationToken);
    }
}
