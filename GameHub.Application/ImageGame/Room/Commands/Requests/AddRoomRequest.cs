using GameHub.Application.ImageGame.Room.Dto;
using MediatR;
using static GameHub.Application.ImageGame.Room.Commands.Requests.AddRoomRequest;

namespace GameHub.Application.ImageGame.Room.Commands.Requests;

public record AddRoomRequest(RoomDto RoomDto) : IRequest<Response>
{
    public const string route = "/imageGame/room";

    public record Response(int StatucCode, string? Message = null);
}
