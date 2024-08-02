using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record AddLevelRequest(LevelDto LevelDto) : IRequest<AddLevelRequest.Response>
{
    public const string route = "/wordGame/level";

    public record Response(int StatusCode, string? Message = null);
}
