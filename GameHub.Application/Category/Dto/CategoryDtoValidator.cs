using FluentValidation;

namespace GameHub.Application.Category.Dto;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
