using GameHub.Application.Category.Command.Requests;
using MediatR;
using System.Net;
using System.Net.Http.Json;

namespace GameHub.Application.Category.Command.Handlers;

public class AddCategoryRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<AddCategoryRequest, AddCategoryRequest.Response>
{
    public async Task<AddCategoryRequest.Response> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").PostAsJsonAsync(AddCategoryRequest.route, request, cancellationToken);
        return response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new AddCategoryRequest.Response(400, "Validation failed"),
            HttpStatusCode.UnprocessableEntity => new AddCategoryRequest.Response(422, "Failed to add category"),
            _ => new AddCategoryRequest.Response(200, "Category added successfully"),
        };
    }
}
