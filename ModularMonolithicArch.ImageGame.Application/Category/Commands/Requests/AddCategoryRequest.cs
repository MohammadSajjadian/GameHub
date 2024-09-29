using MediatR;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Category.Commands.Requests;

public record AddCategoryRequest(CategoryDto CategoryDto) : IRequest<AddCategoryRequest.Response>
{
    public const string route = "/imageGame/category";

    public record Response(int StatusCode, string? Message);
}
