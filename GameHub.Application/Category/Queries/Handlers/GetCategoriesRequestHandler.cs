﻿using GameHub.Application.Category.Dto;
using GameHub.Application.Category.Queries.Requests;
using MediatR;
using System.Net.Http.Json;

namespace GameHub.Application.Category.Queries.Handlers;

public class GetCategoriesRequestHandler(IHttpClientFactory httpClientFactory) : IRequestHandler<GetCategoriesRequest, GetCategoriesRequest.Response>
{
    public async Task<GetCategoriesRequest.Response> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
    {
        List<CategoryDto>? categoryDtos = await httpClientFactory.CreateClient("Client").GetFromJsonAsync<List<CategoryDto>>(GetCategoriesRequest.route, cancellationToken);
        return new GetCategoriesRequest.Response(categoryDtos);
    }
}
