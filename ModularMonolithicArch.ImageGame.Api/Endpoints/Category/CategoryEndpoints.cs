using FluentValidation;
using Microsoft.AspNetCore.Http;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;
using ModularMonolithicArch.ImageGame.Application.Category.Repository;

namespace ModularMonolithicArch.ImageGame.Api.Endpoints.Category;

public static class CategoryEndpoints
{
    public static async Task<IResult> CreateAsync(CategoryDto categoryDto, IValidator<CategoryDto> validator, ICategoryService service, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(categoryDto);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        int result = await service.CreateAsync(categoryDto, cancellationToken);
        return result > 0 ? Results.Ok("Category created successfully")
            : Results.UnprocessableEntity("Failed to add category");
    }

    public static async Task<List<CategoryDto>?> GetAllAsync(ICategoryService service, CancellationToken cancellationToken)
        => await service.GetAllAsync(cancellationToken);
}
