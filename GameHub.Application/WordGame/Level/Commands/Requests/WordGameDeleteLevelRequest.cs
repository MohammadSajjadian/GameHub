using MediatR;

namespace GameHub.Application.WordGame.Level.Commands.Requests;

public record WordGameDeleteLevelRequest(int Id) : IRequest<WordGameDeleteLevelRequest.Response>
{
    public const string route = "/level/{id}";

    public record Response(int StatusCode, string? Message = null);
}
