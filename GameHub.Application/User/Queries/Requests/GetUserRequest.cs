using GameHub.Application.User.Dto;
using MediatR;

namespace GameHub.Application.User.Queries.Requests;

public record GetUserRequest(string UserName) : IRequest<GetUserRequest.Response>
{
    public const string route = "/user/{userName}";

    public record Response(ApplicationUserDto? UserDto, int? StatusCode = null, string? Message = null);
}
