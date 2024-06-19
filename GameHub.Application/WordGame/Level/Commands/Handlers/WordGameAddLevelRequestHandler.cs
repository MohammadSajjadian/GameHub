using GameHub.Application.WordGame.Level.Commands.Requests;
using MediatR;
using System.Net;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Commands.Handlers;

public class WordGameAddLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<WordGameAddLevelRequest, WordGameAddLevelRequest.Response>
{
    public async Task<WordGameAddLevelRequest.Response> Handle(WordGameAddLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").PostAsJsonAsync(WordGameAddLevelRequest.route, request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new WordGameAddLevelRequest.Response(400, "Validation failed"),
            HttpStatusCode.Conflict => new WordGameAddLevelRequest.Response(409, "Level already exists"),
            HttpStatusCode.UnprocessableEntity => new WordGameAddLevelRequest.Response(422, "Failed to add level"),
            _ => new WordGameAddLevelRequest.Response(200, "Level added successfully"),
        };
    }
}
