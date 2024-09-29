using MediatR;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;
using ModularMonolithicArch.ImageGame.Application.Room.Queries.Requests;
using System.Net.Http.Json;

namespace ModularMonolithicArch.ImageGame.Application.Room.Queries.Handlers;

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
