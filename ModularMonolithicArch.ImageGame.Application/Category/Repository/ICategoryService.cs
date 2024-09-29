using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Category.Repository;

public interface ICategoryService
{
    Task<int> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
    Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
}
