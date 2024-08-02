using GameHub.Application.WordGame.Level.Commands.Requests;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Handlers;

public class DeleteLevelHandler(IHttpClientFactory httpClient) : IRequestHandler<DeleteLevelRequest, DeleteLevelRequest.Response>
{
    public async Task<DeleteLevelRequest.Response> Handle(DeleteLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").DeleteAsync(DeleteLevelRequest.route.Replace("{id}", request.Id.ToString()), cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new DeleteLevelRequest.Response(400, "Failed to delete level");

        return new DeleteLevelRequest.Response(200, "Level deleted successfully");
    }
}
