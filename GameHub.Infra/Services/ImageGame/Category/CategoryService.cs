using GameHub.Application.ImageGame.Category.Dto;
using GameHub.Application.ImageGame.Category.Mapper;
using GameHub.Application.ImageGame.Category.Repository;
using GameHub.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Services.ImageGame.Category;

public class CategoryService(GameContext db, ICategoryMapper mapper) : ICategoryService
{
    public async Task<int> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = mapper.Map(categoryDto);

        db.Add(category);
        await db.SaveChangesAsync(cancellationToken);

        return category.Id;
    }

    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        => await db.ImageGameCategories
        .Where(c => c.Id == id)
        .ExecuteDeleteAsync(cancellationToken);

    public async Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.ImageGameCategories
        .AsNoTracking()
        .Select(c => new CategoryDto()
        {
            Id = c.Id,
            Name = c.Name,
        })
        .ToListAsync(cancellationToken);

    public async Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        => await db.ImageGameCategories
            .Where(c => c.Id == categoryDto.Id)
            .ExecuteUpdateAsync(c => c
            .SetProperty(p => p.Name, categoryDto.Name), cancellationToken: cancellationToken);
}
