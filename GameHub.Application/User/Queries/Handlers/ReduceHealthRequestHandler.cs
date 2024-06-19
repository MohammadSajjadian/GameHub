using GameHub.Application.User.Queries.Requests;
using MediatR;

namespace GameHub.Application.User.Queries.Handlers;

public class ReduceHealthRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<ReduceHealthRequest, ReduceHealthRequest.Response>
{
    public async Task<ReduceHealthRequest.Response> Handle(ReduceHealthRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").PutAsync(ReduceHealthRequest.route.Replace("{userName}", request.userName), null, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return new ReduceHealthRequest.Response(400, "Can't reduce user health.");

        return new ReduceHealthRequest.Response(200);
    }
}
