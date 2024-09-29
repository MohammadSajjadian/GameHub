using FluentValidation;
using Microsoft.AspNetCore.Http;
using ModularMonolithicArch.WordGame.Application.Level.Commands.Requests;
using ModularMonolithicArch.WordGame.Application.Level.Dto;
using ModularMonolithicArch.WordGame.Application.Level.Repository;

namespace ModularMonolithicArch.WordGame.Api.Endpoints.Level;

public class LevelEndpoints
{
    public static async Task<IResult> CreateAsync(AddLevelRequest request, ILevelService levelService, IValidator<LevelDto> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request.LevelDto);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        int createResult = await levelService.CreateAsync(request.LevelDto, cancellationToken);

        return createResult > 0 ? Results.Ok("Level created successfully") : createResult is -1 ? Results.Conflict("Level already exist") : Results.UnprocessableEntity("Failed to add level");
    }

    public static async Task<LevelDto?> GetAsync(int id, ILevelService levelService, CancellationToken cancellationToken)
        => await levelService.GetAsync(id, cancellationToken);

    public static async Task<LevelDto?> GetNextLevelAsync(int id, int categoryId, ILevelService levelService, CancellationToken cancellationToken)
        => await levelService.GetNextAsync(id, categoryId, cancellationToken);
}
