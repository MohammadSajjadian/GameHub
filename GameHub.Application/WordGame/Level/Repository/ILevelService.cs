using GameHub.Application.WordGame.Level.Dto;

namespace GameHub.Application.WordGame.Level.Repository;

public interface ILevelService
{
    Task<int> CreateAsync(LevelDto levelDto, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateAsync(LevelDto levelDto, CancellationToken cancellationToken);
    Task<LevelDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<LevelDto?> GetNextAsync(int id, int categoryId, CancellationToken cancellationToken);
    Task<List<LevelDto>?> GetAllAsync(CancellationToken cancellationToken);
    Task<List<LevelDto>?> GetAllByIdAsync(int categoryId, CancellationToken cancellationToken);
    Task<bool> IsLevelExistInCreateAsync(int levelNumber, int categoryId, CancellationToken cancellationToken);
    Task<bool> IsLevelExistInUpdateAsync(int levelNumber, int id, int categoryId, CancellationToken cancellationToken);
}
