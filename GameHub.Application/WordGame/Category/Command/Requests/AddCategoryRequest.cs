using GameHub.Application.WordGame.Category.Dto;
using MediatR;

namespace GameHub.Application.WordGame.Category.Command.Requests;

public record AddCategoryRequest(CategoryDto CategoryDto) : IRequest<AddCategoryRequest.Response>
{
    public const string route = "/wordGame/category";

    public record Response(int? StatusCode = null, string? Message = null);
}
