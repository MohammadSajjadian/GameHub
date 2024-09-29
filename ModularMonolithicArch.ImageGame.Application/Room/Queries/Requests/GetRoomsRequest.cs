using MediatR;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Room.Queries.Requests;

public record GetRoomsRequest : IRequest<GetRoomsRequest.Response>
{
    public const string route = "/imageGame/room/all";

    public record Response(List<RoomDto>? RoomDtos);
}
