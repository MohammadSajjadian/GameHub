using GameHub.Application.WordGame.Level.Commands.Requests;
using MediatR;
using System.Net;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Commands.Handlers;

public class WordGameUpdateLevelHandler(IHttpClientFactory httpClient) : IRequestHandler<WordGameUpdateLevelRequest, WordGameUpdateLevelRequest.Response>
{
    public async Task<WordGameUpdateLevelRequest.Response> Handle(WordGameUpdateLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").PutAsJsonAsync(WordGameUpdateLevelRequest.route, request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new WordGameUpdateLevelRequest.Response(400, "Vlidation failed"),
            HttpStatusCode.Conflict => new WordGameUpdateLevelRequest.Response(409, "Level already exists"),
            HttpStatusCode.UnprocessableEntity => new WordGameUpdateLevelRequest.Response(422, "Failed to update level"),
            _ => new WordGameUpdateLevelRequest.Response(200, "Level updated successfully")
        };
    }
}
