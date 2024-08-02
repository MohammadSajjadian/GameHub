using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Queries.Handlers;

public class GetLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<GetLevelRequest, GetLevelRequest.Response>
{
    public async Task<GetLevelRequest.Response> Handle(GetLevelRequest request, CancellationToken cancellationToken)
    {
        LevelDto? levelDto = await httpClient.CreateClient("Client").GetFromJsonAsync<LevelDto>(GetLevelRequest.route.Replace("id", request.Id.ToString()), cancellationToken);

        if (levelDto is null)
            return new GetLevelRequest.Response(null, 404, "Can’t find the level you’re looking for.");

        return new GetLevelRequest.Response(levelDto, 200);
    }
}
