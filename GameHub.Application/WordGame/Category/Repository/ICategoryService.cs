using GameHub.Application.WordGame.Category.Dto;

namespace GameHub.Application.WordGame.Category.Repository;

public interface ICategoryService
{
    Task<int> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
    Task<List<CategoryDto>?> GetAllAsync(CancellationToken cancellationToken);
}
