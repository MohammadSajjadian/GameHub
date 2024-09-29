using MediatR;

namespace ModularMonolithicArch.ImageGame.Application.Room.Commands.Requests;

public record SetWinnerRequest(int Id, int creatorScore, int guestScore) : IRequest<SetWinnerRequest.Response>
{
    public const string route = "/imageGame/room/scores";

    public record Response();
}
