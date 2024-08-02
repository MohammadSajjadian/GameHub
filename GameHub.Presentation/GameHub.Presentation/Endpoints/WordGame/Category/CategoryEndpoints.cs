using FluentValidation;
using GameHub.Application.WordGame.Category.Command.Requests;
using GameHub.Application.WordGame.Category.Dto;
using GameHub.Application.WordGame.Category.Repository;

namespace GameHub.Presentation.Endpoints.WordGame.Category;

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
}
