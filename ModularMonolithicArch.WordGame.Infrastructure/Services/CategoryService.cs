using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.WordGame.Application.Category.Dto;
using ModularMonolithicArch.WordGame.Application.Category.Mapper;
using ModularMonolithicArch.WordGame.Application.Category.Repository;
using ModularMonolithicArch.WordGame.Infrastructure.Context;

namespace ModularMonolithicArch.WordGame.Infrastructure.Services;

public class CategoryService(WordGameContext db, IValidator<CategoryDto> validator, ICategoryMapper mapper) : ICategoryService
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
        return await db.Categories
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(categoryDto);

        if (!validationResult.IsValid)
            return -1;

        return await db.Categories
            .Where(l => l.Id == categoryDto.Id)
            .ExecuteUpdateAsync(l => l
            .SetProperty(p => p.Name, categoryDto.Name), cancellationToken);
    }

    public async Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await db.Categories
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync(cancellationToken);
    }
}
