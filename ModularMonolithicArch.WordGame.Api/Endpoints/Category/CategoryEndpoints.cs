using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using ModularMonolithicArch.User.Contract.Messages.Commands;
using ModularMonolithicArch.WordGame.Application.Category.Command.Requests;
using ModularMonolithicArch.WordGame.Application.Category.Dto;
using ModularMonolithicArch.WordGame.Application.Category.Repository;

namespace ModularMonolithicArch.WordGame.Api.Endpoints.Category;

public static class CategoryEndpoints
{
    public static async Task<IResult> CreateAsync(AddCategoryRequest request, ICategoryService categoryService, IValidator<CategoryDto> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request.CategoryDto);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        int createResult = await categoryService.CreateAsync(request.CategoryDto, cancellationToken);

        return createResult > 0 ? Results.Ok("Category created successfully") : createResult is -1 ? Results.Conflict("Category already exist") : Results.UnprocessableEntity("Failed to add category");
    }


    public static async Task<List<CategoryDto>?> GetCategoriesAsync(ICategoryService categoryService, CancellationToken cancellationToken)
        => await categoryService.GetAllAsync(cancellationToken);


    public static async Task<IResult> DecreaseHealthAsync(string userName, IMediator mediator, CancellationToken cancellationToken)
    {
        bool isSuccess = await mediator.Send(new DecreaseUserHealthRequest(userName), cancellationToken);
        return isSuccess ? Results.Ok() : Results.BadRequest("Can't update user health.");
    }
}
