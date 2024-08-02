using GameHub.Application.WordGame.Level.Commands.Requests;
using MediatR;
using System.Net;
using System.Net.Http.Json;

namespace GameHub.Application.WordGame.Level.Commands.Handlers;

public class AddLevelRequestHandler(IHttpClientFactory httpClient) : IRequestHandler<AddLevelRequest, AddLevelRequest.Response>
{
    public async Task<AddLevelRequest.Response> Handle(AddLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").PostAsJsonAsync(AddLevelRequest.route, request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new AddLevelRequest.Response(400, "Validation failed"),
            HttpStatusCode.Conflict => new AddLevelRequest.Response(409, "Level already exists"),
            HttpStatusCode.UnprocessableEntity => new AddLevelRequest.Response(422, "Failed to add level"),
            _ => new AddLevelRequest.Response(200, "Level added successfully"),
        };
    }
}
