using GameHub.Application.User.Dto;
using GameHub.Application.User.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.User.Queries.Handlers;

public class GetCurrentUserRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetUserRequest, GetUserRequest.Response>
{
    public async Task<GetUserRequest.Response> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var applicationUserDto = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<ApplicationUserDto>(GetUserRequest.route.Replace("{userName}", request.UserName), cancellationToken);

        if (applicationUserDto is null)
            return new GetUserRequest.Response(null, 404, "Can't find user.");

        return new GetUserRequest.Response(applicationUserDto, 200);
    }
}
