using GameHub.Application.ImageGame.Category.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Category.Queries.Requests;

public record GetCategoriesRequest : IRequest<GetCategoriesRequest.Response>
{
    public const string route = "/imageGame/category";

    public record Response(List<CategoryDto>? CategoryDtos);
}
