using FluentValidation;
using GameHub.Application.WordGame.Category.Dto;
using GameHub.Application.WordGame.Level.Dto;
using GameHub.Application.WordGame.Level.Mapper;
using GameHub.Application.WordGame.Level.Repository;
using GameHub.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Services.WordGame.Level;

public class LevelService(GameContext db, IValidator<LevelDto> validator, ILeveMapper mapper) : ILevelService
{
    public async Task<int> CreateAsync(LevelDto levelDto, CancellationToken cancellationToken)
    {
        var level = mapper.Map(levelDto);

        if (await IsLevelExistInCreateAsync(levelDto.LevelNumber, levelDto.CategoryDto.Id, cancellationToken))
            return -1;

        db.Add(level);
        await db.SaveChangesAsync(cancellationToken);

        return level.Id;
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await db.WordGameLevels
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(LevelDto levelDto, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(levelDto);

        if (!validationResult.IsValid)
            return -1;

        if (await IsLevelExistInUpdateAsync(levelDto.LevelNumber, levelDto.Id, levelDto.CategoryDto.Id, cancellationToken))
            return -2;

        return await db.WordGameLevels
            .Where(l => l.Id == levelDto.Id)
            .ExecuteUpdateAsync(l => l
            .SetProperty(p => p.LevelNumber, levelDto.LevelNumber)
            .SetProperty(p => p.Word, levelDto.Word)
            .SetProperty(p => p.Hint, levelDto.Hint)
            .SetProperty(p => p.CategoryId, levelDto.CategoryDto.Id)
            .SetProperty(p => p.LevelStatus, levelDto.LevelStatus), cancellationToken);
    }

    public async Task<LevelDto?> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await db.WordGameLevels
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new LevelDto
            {
                Word = x.Word,
                Hint = x.Hint,
                LevelStatus = x.LevelStatus
            }).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<LevelDto?> GetNextAsync(int id, int categoryId, CancellationToken cancellationToken)
    {
        var currentLevel = await db.WordGameLevels
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        if (currentLevel is null) return null;

        var nextLevel = await db.WordGameLevels
        .AsNoTracking()
            .Where(l => l.CategoryId == categoryId && l.LevelNumber > currentLevel.LevelNumber)
            .OrderBy(l => l.LevelNumber)
            .Select(l => new LevelDto
            {
                Id = l.Id,
                Word = l.Word,
                Hint = l.Hint,
                LevelStatus = l.LevelStatus
            }).FirstOrDefaultAsync(cancellationToken);

        return nextLevel;
    }

    public async Task<List<LevelDto>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await db.WordGameLevels
            .AsNoTracking()
            .OrderBy(l => l.LevelNumber)
            .Select(l => new LevelDto
            {
                Id = l.Id,
                LevelNumber = l.LevelNumber,
                Word = l.Word,
                Hint = l.Hint,
                CategoryDto = new CategoryDto { Id = l.CategoryId, Name = l.Category.Name },
                LevelStatus = l.LevelStatus
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<List<LevelDto>?> GetAllByIdAsync(int categoryId, CancellationToken cancellationToken)
    {
        return await db.WordGameLevels
            .AsNoTracking()
            .Where(l => l.CategoryId == categoryId)
            .OrderBy(l => l.LevelNumber)
            .Select(l => new LevelDto
            {
                Id = l.Id,
                LevelNumber = l.LevelNumber,
                Word = l.Word,
                Hint = l.Hint,
                CategoryDto = new CategoryDto { Id = l.CategoryId, Name = l.Category.Name },
                LevelStatus = l.LevelStatus
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsLevelExistInCreateAsync(int levelNumber, int categoryId, CancellationToken cancellationToken)
        => await db.WordGameLevels.AnyAsync(x => x.CategoryId == categoryId && x.LevelNumber == levelNumber, cancellationToken);

    public async Task<bool> IsLevelExistInUpdateAsync(int levelNumber, int id, int categoryId, CancellationToken cancellationToken)
        => await db.WordGameLevels.AnyAsync(x => x.CategoryId == categoryId && x.LevelNumber == levelNumber && x.Id != id, cancellationToken);
}
