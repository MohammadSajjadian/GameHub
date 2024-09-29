using MediatR;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;
using ModularMonolithicArch.ImageGame.Application.Room.Queries.Requests;
using System.Net.Http.Json;

namespace ModularMonolithicArch.ImageGame.Application.Room.Queries.Handlers;

public class GetRoomsRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetRoomsRequest, GetRoomsRequest.Response>
{
    public async Task<GetRoomsRequest.Response> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        var roomDtos = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<List<RoomDto>?>(GetRoomsRequest.route, cancellationToken);
        return new GetRoomsRequest.Response(roomDtos);
    }
}
