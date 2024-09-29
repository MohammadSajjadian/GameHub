using MediatR;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;
using ModularMonolithicArch.ImageGame.Application.Category.Queries.Requests;
using System.Net.Http.Json;

namespace ModularMonolithicArch.ImageGame.Application.Category.Queries.Handlers;

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
