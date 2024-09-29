using MediatR;
using ModularMonolithicArch.WordGame.Application.Category.Dto;

namespace ModularMonolithicArch.WordGame.Application.Category.Command.Requests;

public record AddCategoryRequest(CategoryDto CategoryDto) : IRequest<AddCategoryRequest.Response>
{
    public const string route = "/wordGame/category";

    public record Response(int? StatusCode = null, string? Message = null);
}
