using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record UpdateLevelRequest(LevelDto LevelDto) : IRequest<UpdateLevelRequest.Response>
{
    public const string route = "/wordGame/level";

    public record Response(int StatusCode, string? Messgae = null);
}
