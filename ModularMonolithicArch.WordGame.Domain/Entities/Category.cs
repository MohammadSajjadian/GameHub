using ModularMonolithicArch.WordGame.Domain.Base;

namespace ModularMonolithicArch.WordGame.Domain.Entities;

public class Category : CategoryBase
{
    public ICollection<Level> Levels { get; set; } = default!;
}
