using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record DeleteLevelRequest(int Id) : IRequest<DeleteLevelRequest.Response>
{
    public const string route = "/wordGame/level/{id}";

    public record Response(int StatusCode, string? Message = null);
}
