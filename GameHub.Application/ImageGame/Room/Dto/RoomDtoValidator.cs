using FluentValidation;

namespace GameHub.Application.ImageGame.Room.Dto;

public class RoomDtoValidator : AbstractValidator<RoomDto>
{
    public RoomDtoValidator()
    {
        RuleFor(r => r.CategoryId).NotEmpty().WithMessage("'Category' must not be empty.");

        RuleFor(r => r.Time)
            .NotEmpty().WithMessage("'Game Time' must not be empty.")
            .GreaterThanOrEqualTo(20)
            .LessThanOrEqualTo(120);

        RuleFor(r => r.BoardSize).NotEmpty();
    }
}
