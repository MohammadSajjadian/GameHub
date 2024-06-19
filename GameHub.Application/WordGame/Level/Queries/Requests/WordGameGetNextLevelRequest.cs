using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Queries.Requests;

public record WordGameGetNextLevelRequest(int Id, int CategoryId) : IRequest<WordGameGetNextLevelRequest.GetNextLevelResponse>
{
    public const string route = "level/{id}/category/{categoryId}/next";

    public record GetNextLevelResponse(WordGameLevelDto? LevelDto, int? StatusCode = null, string? Message = null);
}
