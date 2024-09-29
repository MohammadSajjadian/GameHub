using MediatR;
using ModularMonolithicArch.WordGame.Application.Category.Dto;

namespace ModularMonolithicArch.WordGame.Application.Category.Queries.Requests;

public record GetCategoriesRequest : IRequest<GetCategoriesRequest.Response>
{
    public const string route = "/wordGame/category";

    public record Response(List<CategoryDto>? CategoryDtos, int? StatusCode = null, string? Message = null);
}
