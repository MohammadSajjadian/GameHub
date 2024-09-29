using MediatR;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Room.Queries.Requests;

public record GetRoomRequest(int Id) : IRequest<GetRoomRequest.Response>
{
    public const string route = "/imageGame/room/id";

    public record Response(RoomDto? RoomDto, string? Message = null);
}
