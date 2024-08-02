using GameHub.Application.ImageGame.Room.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Room.Queries.Requests;

public record GetRoomsRequest : IRequest<GetRoomsRequest.Response>
{
    public const string route = "/imageGame/room/all";

    public record Response(List<RoomDto>? RoomDtos);
}
