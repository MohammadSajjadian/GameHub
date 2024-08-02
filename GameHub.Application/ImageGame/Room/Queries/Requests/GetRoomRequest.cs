using GameHub.Application.ImageGame.Room.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Room.Queries.Requests;

public record GetRoomRequest(int Id) : IRequest<GetRoomRequest.Response>
{
    public const string route = "/imageGame/room/id";

    public record Response(RoomDto? RoomDto, string? Message = null);
}
