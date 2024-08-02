using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace GameHub.Application.ImageGame.Image.Dto;

public class IFormFileValidator : AbstractValidator<IFormFile>
{
    public IFormFileValidator()
    {
        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(i => i.Length)
            .LessThanOrEqualTo(2 * 1024 * 1024) // 2 MB in bytes
            .WithMessage("'Size' must be less than or equal to 2 MB.");

        RuleFor(i => i.FileName)
            .Must(x => x.Contains("jpeg") || x.Contains("jpg") || x.Contains("png"))
            .WithMessage("File type is not allowed. Only JPEG and PNG formats are accepted.");
    }
}
