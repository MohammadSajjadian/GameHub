using FluentValidation;

namespace GameHub.Application.ImageGame.Image.Dto;

public class ImageValidator : AbstractValidator<ImageDto>
{
    public ImageValidator()
    {
        RuleFor(i => i.CategoryDto.Id).NotEmpty().WithMessage("'Category' must not be empty.");
    }
}
