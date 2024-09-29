using MediatR;
using ModularMonolithicArch.WordGame.Application.Level.Commands.Requests;
using System.Net;
using System.Net.Http.Json;

namespace ModularMonolithicArch.WordGame.Application.Level.Commands.Handlers;

public class UpdateLevelHandler(IHttpClientFactory httpClient) : IRequestHandler<UpdateLevelRequest, UpdateLevelRequest.Response>
{
    public async Task<UpdateLevelRequest.Response> Handle(UpdateLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").PutAsJsonAsync(UpdateLevelRequest.route, request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new UpdateLevelRequest.Response(400, "Vlidation failed"),
            HttpStatusCode.Conflict => new UpdateLevelRequest.Response(409, "Level already exists"),
            HttpStatusCode.UnprocessableEntity => new UpdateLevelRequest.Response(422, "Failed to update level"),
            _ => new UpdateLevelRequest.Response(200, "Level updated successfully")
        };
    }
}
