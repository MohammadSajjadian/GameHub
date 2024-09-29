using MediatR;
using ModularMonolithicArch.ImageGame.Application.Image.Commands.Requests;
using System.Net.Http.Json;

namespace ModularMonolithicArch.ImageGame.Application.Image.Commands.Handlers;

public class AddImageRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<AddImageRequest, AddImageRequest.Response>
{
    public async Task<AddImageRequest.Response> Handle(AddImageRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").PostAsJsonAsync(AddImageRequest.route, request.ImageDto, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return new(400, 0, "Failed to create image.");

        int imageId = await response.Content.ReadFromJsonAsync<int>(cancellationToken);
        return new(200, imageId);
    }
}
