using MediatR;
using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Queries.Requests;

public record GetNextLevelRequest(int Id, int CategoryId) : IRequest<GetNextLevelRequest.GetNextLevelResponse>
{
    public const string route = "/wordGame/level/{id}/category/{categoryId}/next";

    public record GetNextLevelResponse(LevelDto? LevelDto, int? StatusCode = null, string? Message = null);
}
