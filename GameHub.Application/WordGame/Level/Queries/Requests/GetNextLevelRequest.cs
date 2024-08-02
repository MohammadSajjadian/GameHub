using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Queries.Requests;

public record GetNextLevelRequest(int Id, int CategoryId) : IRequest<GetNextLevelRequest.GetNextLevelResponse>
{
    public const string route = "/wordGame/level/{id}/category/{categoryId}/next";

    public record GetNextLevelResponse(LevelDto? LevelDto, int? StatusCode = null, string? Message = null);
}
