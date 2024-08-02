using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Queries.Handlers;

public class GetNextLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<GetNextLevelRequest, GetNextLevelRequest.GetNextLevelResponse>
{
    public async Task<GetNextLevelRequest.GetNextLevelResponse> Handle(GetNextLevelRequest request, CancellationToken cancellationToken)
    {
        string route = GetNextLevelRequest.route.Replace("{id}", request.Id.ToString()).Replace("{categoryId}", request.CategoryId.ToString());
        LevelDto? levelDto = await httpClient.CreateClient("Client").GetFromJsonAsync<LevelDto>(route, cancellationToken);

        if (levelDto is null)
            return new GetNextLevelRequest.GetNextLevelResponse(null, 404, Message: "Can’t find the level you’re looking for.");

        return new GetNextLevelRequest.GetNextLevelResponse(levelDto, 200);
    }
}
