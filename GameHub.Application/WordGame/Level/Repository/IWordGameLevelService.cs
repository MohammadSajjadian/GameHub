using GameHub.Application.WordGame.Level.Dto;

namespace GameHub.Application.WordGame.Level.Repository;

public interface IWordGameLevelService
{
    Task<int> CreateAsync(WordGameLevelDto levelDto, CancellationToken cancellationToken);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateAsync(WordGameLevelDto levelDto, CancellationToken cancellationToken);
    Task<WordGameLevelDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<WordGameLevelDto?> GetNextAsync(int id, int categoryId, CancellationToken cancellationToken);
    Task<List<WordGameLevelDto>?> GetAllAsync(CancellationToken cancellationToken);
    Task<List<WordGameLevelDto>?> GetAllByIdAsync(int categoryId, CancellationToken cancellationToken);
    Task<bool> IsLevelExistInCreateAsync(int levelNumber, int categoryId, CancellationToken cancellationToken);
    Task<bool> IsLevelExistInUpdateAsync(int levelNumber, int id, int categoryId, CancellationToken cancellationToken);
}
