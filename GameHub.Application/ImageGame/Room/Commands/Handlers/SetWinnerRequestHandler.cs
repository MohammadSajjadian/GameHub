using GameHub.Application.ImageGame.Room.Commands.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Room.Commands.Handlers;

public class SetWinnerRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<SetWinnerRequest, SetWinnerRequest.Response>
{
    public async Task<SetWinnerRequest.Response> Handle(SetWinnerRequest request, CancellationToken cancellationToken)
    {
        await httpClientFactory.CreateClient("Client").PutAsJsonAsync(SetWinnerRequest.route, request, cancellationToken);
        return new SetWinnerRequest.Response();
    }
}
