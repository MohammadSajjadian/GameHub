using MediatR;
using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Queries.Requests;

public record GetLevelRequest(int Id) : IRequest<GetLevelRequest.Response>
{
    public const string route = "/wordGame/level/id";

    public record Response(LevelDto? LevelDto, int? StatusCode = null, string? Message = null);
}
