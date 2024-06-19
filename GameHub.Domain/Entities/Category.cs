using GameHub.Domain.Entities.WordGame;

namespace GameHub.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<WordGameLevel> WordGameLevels { get; set; } = default!;
}
