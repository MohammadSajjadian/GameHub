using MediatR;

namespace GameHub.Application.ImageGame.Room.Commands.Requests;

public record DeleteRoomRequest(int Id) : IRequest<DeleteRoomRequest.Response>
{
    public const string route = "/imageGame/room/id";

    public record Response(int StatusCode);
}
