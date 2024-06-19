using GameHub.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Domain.Entities.WordGame;

public class WordGameLevel
{
    public int Id { get; set; }
    public int LevelNumber { get; set; }
    public string Word { get; set; } = default!;
    public string Hint { get; set; } = default!;

    public LevelStatus LevelStatus { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
