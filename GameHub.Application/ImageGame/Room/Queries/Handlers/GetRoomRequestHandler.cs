using GameHub.Application.ImageGame.Room.Dto;
using GameHub.Application.ImageGame.Room.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Room.Queries.Handlers;

public class GetRoomRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetRoomRequest, GetRoomRequest.Response>
{
    public async Task<GetRoomRequest.Response> Handle(GetRoomRequest request, CancellationToken cancellationToken)
    {
        RoomDto? roomDto = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<RoomDto?>(GetRoomRequest.route.Replace("id", request.Id.ToString()), cancellationToken);
        if (roomDto is null)
            return new GetRoomRequest.Response(null, "The room you’re looking for does not exist.");

        return new GetRoomRequest.Response(roomDto);
    }
}
