using GameHub.Application.Category.Dto;
using MediatR;

namespace GameHub.Application.Category.Queries.Requests;

public record GetCategoriesRequest : IRequest<GetCategoriesRequest.Response>
{
    public const string route = "/category";

    public record Response(List<CategoryDto>? CategoryDtos, int? StatusCode = null, string? Message = null);
}
