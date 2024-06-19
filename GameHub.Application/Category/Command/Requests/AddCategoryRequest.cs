using GameHub.Application.Category.Dto;
using MediatR;

namespace GameHub.Application.Category.Command.Requests;

public record AddCategoryRequest(CategoryDto CategoryDto) : IRequest<AddCategoryRequest.Response>
{
    public const string route = "/category";

    public record Response(int? StatusCode = null, string? Message = null);
}
