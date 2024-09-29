namespace ModularMonolithicArch.WordGame.Domain.Base;

public abstract class CategoryBase
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
