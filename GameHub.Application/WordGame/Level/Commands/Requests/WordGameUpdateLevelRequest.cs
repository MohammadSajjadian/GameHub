using GameHub.Application.WordGame.Level.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record WordGameUpdateLevelRequest(WordGameLevelDto LevelDto) : IRequest<WordGameUpdateLevelRequest.Response>
{
    public const string route = "/level";

    public record Response(int StatusCode, string? Messgae = null);
}
