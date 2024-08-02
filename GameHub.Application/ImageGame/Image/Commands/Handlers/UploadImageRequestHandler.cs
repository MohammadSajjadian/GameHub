using GameHub.Application.ImageGame.Image.Commands.Requests;
using MediatR;

namespace GameHub.Application.ImageGame.Image.Commands.Handlers;

public class UploadImageRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<UploadImageRequest, UploadImageRequest.Response>
{
    private const long _maxSize = 1024 * 1024 * 2;

    public async Task<UploadImageRequest.Response> Handle(UploadImageRequest request, CancellationToken cancellationToken)
    {
        var stream = request.File.OpenReadStream(request.File.Size, cancellationToken);
        var content = new MultipartFormDataContent { { new StreamContent(stream), "image", request.File.Name } };

        var route = UploadImageRequest.route.Replace("imageId", request.ImageId.ToString());
        var response = await httpClientFactory.CreateClient("Client").PostAsync(route, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new(400, "Failed to upload image.");

        return new(200, "Image created successfully");
    }
}
