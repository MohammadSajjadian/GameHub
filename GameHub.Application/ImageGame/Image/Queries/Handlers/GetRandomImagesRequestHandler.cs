using GameHub.Application.ImageGame.Image.Dto;
using GameHub.Application.ImageGame.Image.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Image.Queries.Handlers;

public class GetRandomImagesRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetRandomImagesRequest, GetRandomImagesRequest.Response>
{
    public async Task<GetRandomImagesRequest.Response> Handle(GetRandomImagesRequest request, CancellationToken cancellationToken)
    {
        string route = GetRandomImagesRequest.route
            .Replace("categoryId", request.CategoryId.ToString()).Replace("boardSize", request.BoardSize.ToString()).Replace("seed", request.Seed.ToString());
        var imageDtos = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<List<ImageDto>?>(route, cancellationToken);
        return new(imageDtos);
    }
}
