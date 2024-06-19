using FluentValidation;
using GameHub.Application.Level.Dto;
using GameHub.Application.Level.Repository;

namespace GameHub.Api.Endpoints.Level;

public static class LevelEndpoints
{
    public static async Task<IResult> CreateLevel(LevelDto levelDto, ILevelService levelService, IValidator<LevelDto> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(levelDto);

        if (!validationResult.IsValid)
            return Results.BadRequest("Parameters validation failed.");

        int createResult = await levelService.CreateLevelAsync(levelDto, cancellationToken);

        return createResult > 0 ? Results.Ok() : Results.BadRequest("Failed to add level");
    }
}
