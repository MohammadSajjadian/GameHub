using MediatR;
using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Commands.Requests;

public record AddLevelRequest(LevelDto LevelDto) : IRequest<AddLevelRequest.Response>
{
    public const string route = "/wordGame/level";

    public record Response(int StatusCode, string? Message = null);
}
