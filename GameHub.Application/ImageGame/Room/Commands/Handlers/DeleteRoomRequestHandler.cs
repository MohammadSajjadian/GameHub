using GameHub.Application.ImageGame.Room.Commands.Requests;
using MediatR;

namespace GameHub.Application.ImageGame.Room.Commands.Handlers;

public class DeleteRoomRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<DeleteRoomRequest, DeleteRoomRequest.Response>
{
    public async Task<DeleteRoomRequest.Response> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").DeleteAsync(DeleteRoomRequest.route.Replace("id", request.Id.ToString()), cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new DeleteRoomRequest.Response(400);

        return new DeleteRoomRequest.Response(200);
    }
}
