using FluentValidation;
using GameHub.Application.WordGame.Level.Commands.Requests;
using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Repository;

namespace GameHub.Presentation.Endpoints.WordGame.Level;

public class WordGameLevelEndpoints
{
    public static async Task<IResult> CreateAsync(WordGameAddLevelRequest request, IWordGameLevelService levelService, IValidator<WordGameLevelDto> validator, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request.LevelDto);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        int createResult = await levelService.CreateAsync(request.LevelDto, cancellationToken);

        return createResult > 0 ? Results.Ok("Level created successfully") : createResult is -1 ? Results.Conflict("Level already exist") : Results.UnprocessableEntity("Failed to add level");
    }

    public static async Task<WordGameLevelDto?> GetAsync(int id, IWordGameLevelService levelService, CancellationToken cancellationToken)
        => await levelService.GetAsync(id, cancellationToken);

    public static async Task<WordGameLevelDto?> GetNextLevelAsync(int id, int categoryId, IWordGameLevelService levelService, CancellationToken cancellationToken)
        => await levelService.GetNextAsync(id, categoryId, cancellationToken);
}
