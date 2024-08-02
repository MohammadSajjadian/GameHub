using GameHub.Application.ImageGame.Category.Dto;
using MediatR;

namespace GameHub.Application.ImageGame.Category.Commands.Requests;

public record AddCategoryRequest(CategoryDto CategoryDto) : IRequest<AddCategoryRequest.Response>
{
    public const string route = "/imageGame/category";

    public record Response(int StatusCode, string? Message);
}
