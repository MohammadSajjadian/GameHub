using GameHub.Application.WordGame.Level.Commands.Requests;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Handlers;

public class WordGameDeleteLevelHandler(IHttpClientFactory httpClient) : IRequestHandler<WordGameDeleteLevelRequest, WordGameDeleteLevelRequest.Response>
{
    public async Task<WordGameDeleteLevelRequest.Response> Handle(WordGameDeleteLevelRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClient.CreateClient("Client").DeleteAsync(WordGameDeleteLevelRequest.route.Replace("{id}", request.Id.ToString()), cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new WordGameDeleteLevelRequest.Response(400, "Failed to delete level");

        return new WordGameDeleteLevelRequest.Response(200, "Level deleted successfully");
    }
}
