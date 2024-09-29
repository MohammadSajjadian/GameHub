using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.ImageGame.Application.Category.Dto;
using ModularMonolithicArch.ImageGame.Application.Category.Mapper;
using ModularMonolithicArch.ImageGame.Application.Category.Repository;
using ModularMonolithicArch.ImageGame.Infrastructure.Context;

namespace ModularMonolithicArch.ImageGame.Infrastructure.Services;

public class CategoryService(ImageGameContext db, ICategoryMapper mapper) : ICategoryService
{
    public async Task<int> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = mapper.Map(categoryDto);

        db.Add(category);
        await db.SaveChangesAsync(cancellationToken);

        return category.Id;
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        => await db.Categories
        .Where(c => c.Id == id)
        .ExecuteDeleteAsync(cancellationToken);

    public async Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.Categories
        .AsNoTracking()
        .Select(c => new CategoryDto()
        {
            Id = c.Id,
            Name = c.Name,
        })
        .ToListAsync(cancellationToken);

    public async Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        => await db.Categories
            .Where(c => c.Id == categoryDto.Id)
            .ExecuteUpdateAsync(c => c
            .SetProperty(p => p.Name, categoryDto.Name), cancellationToken: cancellationToken);
}
