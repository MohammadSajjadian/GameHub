using MediatR;
using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Commands.Requests;

public record UpdateLevelRequest(LevelDto LevelDto) : IRequest<UpdateLevelRequest.Response>
{
    public const string route = "/wordGame/level";

    public record Response(int StatusCode, string? Messgae = null);
}
