using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Queries.Handlers;

public class WordGameGetNextLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<WordGameGetNextLevelRequest, WordGameGetNextLevelRequest.GetNextLevelResponse>
{
    public async Task<WordGameGetNextLevelRequest.GetNextLevelResponse> Handle(WordGameGetNextLevelRequest request, CancellationToken cancellationToken)
    {
        string route = WordGameGetNextLevelRequest.route.Replace("{id}", request.Id.ToString()).Replace("{categoryId}", request.CategoryId.ToString());
        WordGameLevelDto? levelDto = await httpClient.CreateClient("Client").GetFromJsonAsync<WordGameLevelDto>(route, cancellationToken);

        if (levelDto is null)
            return new WordGameGetNextLevelRequest.GetNextLevelResponse(null, 404, Message: "Can’t find the level you’re looking for.");

        return new WordGameGetNextLevelRequest.GetNextLevelResponse(levelDto, 200);
    }
}
