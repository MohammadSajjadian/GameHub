using GameHub.Domain.Entities.Base;

namespace GameHub.Domain.Entities.WordGame;

public class Category : CategoryBase
{
    public ICollection<Level> Levels { get; set; } = default!;
}
