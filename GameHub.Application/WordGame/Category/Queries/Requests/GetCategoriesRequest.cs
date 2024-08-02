using GameHub.Application.WordGame.Category.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Category.Queries.Requests;

public record GetCategoriesRequest : IRequest<GetCategoriesRequest.Response>
{
    public const string route = "/wordGame/category";

    public record Response(List<CategoryDto>? CategoryDtos, int? StatusCode = null, string? Message = null);
}
