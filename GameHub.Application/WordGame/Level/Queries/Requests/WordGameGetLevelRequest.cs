using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Queries.Requests;

public record WordGameGetLevelRequest(int Id) : IRequest<WordGameGetLevelRequest.Response>
{
    public const string route = "/level/id";

    public record Response(WordGameLevelDto? LevelDto, int? StatusCode = null, string? Message = null);
}
