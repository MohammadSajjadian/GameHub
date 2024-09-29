using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.WordGame.Application.Category.Dto;
using ModularMonolithicArch.WordGame.Application.Level.Dto;
using ModularMonolithicArch.WordGame.Application.Level.Mapper;
using ModularMonolithicArch.WordGame.Application.Level.Repository;
using ModularMonolithicArch.WordGame.Infrastructure.Context;

namespace ModularMonolithicArch.WordGame.Infrastructure.Services;

public class LevelService(WordGameContext db, IValidator<LevelDto> validator, ILeveMapper mapper) : ILevelService
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
        return await db.Levels
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

        return await db.Levels
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
        return await db.Levels
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
        var currentLevel = await db.Levels
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        if (currentLevel is null) return null;

        var nextLevel = await db.Levels
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
        return await db.Levels
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
        return await db.Levels
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
        => await db.Levels.AnyAsync(x => x.CategoryId == categoryId && x.LevelNumber == levelNumber, cancellationToken);

    public async Task<bool> IsLevelExistInUpdateAsync(int levelNumber, int id, int categoryId, CancellationToken cancellationToken)
        => await db.Levels.AnyAsync(x => x.CategoryId == categoryId && x.LevelNumber == levelNumber && x.Id != id, cancellationToken);
}
