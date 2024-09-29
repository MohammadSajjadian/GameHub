using FluentValidation;

namespace ModularMonolithicArch.ImageGame.Application.Category.Dto;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("'Name' must not be empty.");
    }
}
