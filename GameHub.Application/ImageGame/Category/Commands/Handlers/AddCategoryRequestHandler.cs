using GameHub.Application.ImageGame.Category.Commands.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Category.Commands.Handlers;

public class AddCategoryRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<AddCategoryRequest, AddCategoryRequest.Response>
{
    public async Task<AddCategoryRequest.Response> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await httpClientFactory.CreateClient("Client").PostAsJsonAsync(AddCategoryRequest.route, request.CategoryDto, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return new AddCategoryRequest.Response(400, "Failed to create category.");

        return new AddCategoryRequest.Response(200, "Category created successfully.");
    }
}
