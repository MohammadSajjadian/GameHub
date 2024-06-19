using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record WordGameAddLevelRequest(WordGameLevelDto LevelDto) : IRequest<WordGameAddLevelRequest.Response>
{
    public const string route = "/level";

    public record Response(int StatusCode, string? Message = null);
}
