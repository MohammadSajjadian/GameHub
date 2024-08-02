using GameHub.Application.ImageGame.Room.Commands.Requests;
using MediatR;
using System.Net;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Room.Commands.Handlers;

public class AddRoomRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<AddRoomRequest, AddRoomRequest.Response>
{
    public async Task<AddRoomRequest.Response> Handle(AddRoomRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").PostAsJsonAsync(AddRoomRequest.route, request.RoomDto, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new AddRoomRequest.Response(400, "You already have a room. You should delete it to create a new one."),
            HttpStatusCode.UnprocessableEntity => new AddRoomRequest.Response(422, "Failed to add room"),
            _ => new AddRoomRequest.Response(200, "Room created successfully."),
        };
    }
}
