using ModularMonolithicArch.WordGame.Application.Category.Dto;
using ModularMonolithicArch.WordGame.Domain.Enums;

namespace ModularMonolithicArch.WordGame.Application.Level.Dto;

public class LevelDto
{
    public int Id { get; set; }
    public int LevelNumber { get; set; }
    public string Word { get; set; } = default!;
    public string Hint { get; set; } = default!;

    public CategoryDto CategoryDto { get; set; } = new();
    public LevelStatus LevelStatus { get; set; }
}
