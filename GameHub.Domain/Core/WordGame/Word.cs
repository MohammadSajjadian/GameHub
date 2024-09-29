namespace GameHub.Domain.Core.WordGame;

public class Word
{
    public string Value { get; set; } = default!;
    public List<Letter> Letters { get; set; } = [];
}
