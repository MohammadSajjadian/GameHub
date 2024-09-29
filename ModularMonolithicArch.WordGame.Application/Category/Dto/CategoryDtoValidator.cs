using FluentValidation;

namespace ModularMonolithicArch.WordGame.Application.Category.Dto;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
