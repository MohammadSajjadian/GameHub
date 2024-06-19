using FluentValidation;

namespace GameHub.Application.WordGame.Level.Dto;

public class WordGameLevelDtoValidator : AbstractValidator<WordGameLevelDto>
{
    public WordGameLevelDtoValidator()
    {
        RuleFor(x => x.LevelNumber)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.Word)
            .NotEmpty()
            .Matches(@"^[a-zA-Z]*$").WithMessage("Word should only include alphabetic charecters (no numbers or special characters)");

        RuleFor(x => x.Hint).NotEmpty();

        RuleFor(x => x.CategoryDto.Id).NotEmpty().WithMessage("'Category' must not be empty.");

        RuleFor(x => x.LevelStatus)
            .NotEmpty().WithMessage("'Difficulty' must not be empty.");
    }
}
