using MediatR;

namespace GameHub.Application.User.Queries.Requests;

public record ReduceHealthRequest(string userName) : IRequest<ReduceHealthRequest.Response>
{
    public const string route = "/user/{userName}/reduceHealth";

    public record Response(int? StatusCode = null, string? Message = null);
}
