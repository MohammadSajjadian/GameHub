using MediatR;

namespace ModularMonolithicArch.ImageGame.Application.Room.Commands.Requests;

public record DeleteRoomRequest(int Id) : IRequest<DeleteRoomRequest.Response>
{
    public const string route = "/imageGame/room/id";

    public record Response(int StatusCode);
}
