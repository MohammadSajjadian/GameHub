using FluentValidation;
using GameHub.Application.WordGame.Category.Dto;
using GameHub.Application.WordGame.Category.Mapper;
using GameHub.Application.WordGame.Category.Repository;
using GameHub.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Services.WordGame.Category;

public class CategoryService(GameContext db, IValidator<CategoryDto> validator, ICategoryMapper mapper) : ICategoryService
{
    public async Task<int> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = mapper.Map(categoryDto);

        db.Add(category);
        await db.SaveChangesAsync(cancellationToken);

        return category.Id;
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        return await db.WordGameCategories
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(categoryDto);

        if (!validationResult.IsValid)
            return -1;

        return await db.WordGameCategories
            .Where(l => l.Id == categoryDto.Id)
            .ExecuteUpdateAsync(l => l
            .SetProperty(p => p.Name, categoryDto.Name), cancellationToken);
    }

    public async Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await db.WordGameCategories
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync(cancellationToken);
    }
}
