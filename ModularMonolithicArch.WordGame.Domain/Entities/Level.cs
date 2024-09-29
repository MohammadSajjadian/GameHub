using ModularMonolithicArch.WordGame.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModularMonolithicArch.WordGame.Domain.Entities;

public class Level
{
    public int Id { get; set; }
    public int LevelNumber { get; set; }
    public string Word { get; set; } = default!;
    public string Hint { get; set; } = default!;

    public LevelStatus LevelStatus { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = default!;
}
