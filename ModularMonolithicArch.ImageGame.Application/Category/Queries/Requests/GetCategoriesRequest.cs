using MediatR;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Category.Queries.Requests;

public record GetCategoriesRequest : IRequest<GetCategoriesRequest.Response>
{
    public const string route = "/imageGame/category";

    public record Response(List<CategoryDto>? CategoryDtos);
}
