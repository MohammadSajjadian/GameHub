using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Queries.Handlers;

public class WordGameGetLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<WordGameGetLevelRequest, WordGameGetLevelRequest.Response>
{
    public async Task<WordGameGetLevelRequest.Response> Handle(WordGameGetLevelRequest request, CancellationToken cancellationToken)
    {
        WordGameLevelDto? levelDto = await httpClient.CreateClient("Client").GetFromJsonAsync<WordGameLevelDto>(WordGameGetLevelRequest.route.Replace("id", request.Id.ToString()), cancellationToken);

        if (levelDto is null)
            return new WordGameGetLevelRequest.Response(null, 404, "Can’t find the level you’re looking for.");

        return new WordGameGetLevelRequest.Response(levelDto, 200);
    }
}
