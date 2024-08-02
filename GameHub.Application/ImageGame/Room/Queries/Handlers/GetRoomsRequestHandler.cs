using GameHub.Application.ImageGame.Room.Dto;
using GameHub.Application.ImageGame.Room.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Room.Queries.Handlers;

public class GetRoomsRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetRoomsRequest, GetRoomsRequest.Response>
{
    public async Task<GetRoomsRequest.Response> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        var roomDtos = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<List<RoomDto>?>(GetRoomsRequest.route, cancellationToken);
        return new GetRoomsRequest.Response(roomDtos);
    }
}
