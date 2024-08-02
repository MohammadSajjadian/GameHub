using GameHub.Application.ImageGame.Category.Dto;
using GameHub.Application.ImageGame.Category.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.ImageGame.Category.Queries.Handlers;

public class GetCategoriesRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetCategoriesRequest, GetCategoriesRequest.Response>
{
    public async Task<GetCategoriesRequest.Response> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categoryDtos = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<List<CategoryDto>?>(GetCategoriesRequest.route, cancellationToken);
        if (categoryDtos is null)
            return new GetCategoriesRequest.Response(null);
        
        return new GetCategoriesRequest.Response(categoryDtos);
    }
}
