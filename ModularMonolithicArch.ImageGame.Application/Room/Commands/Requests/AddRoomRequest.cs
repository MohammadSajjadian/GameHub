using MediatR;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;
using static ModularMonolithicArch.ImageGame.Application.Room.Commands.Requests.AddRoomRequest;

namespace ModularMonolithicArch.ImageGame.Application.Room.Commands.Requests;

public record AddRoomRequest(RoomDto RoomDto) : IRequest<Response>
{
    public const string route = "/imageGame/room";

    public record Response(int StatucCode, string? Message = null);
}
