using ModularMonolithicArch.ImageGame.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModularMonolithicArch.ImageGame.Domain.Entities;

public class Room
{
    public int Id { get; set; }

    public int CategoryId { get; set; } = default!;
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = default!;

    public string CreatorId { get; set; } = default!;
    public string CreatorUserName { get; set; } = string.Empty;

    public string? GuestId { get; set; }
    public string? GuestUserName { get; set; }

    public string ConnectionId { get; set; } = default!;

    public int? CreatorScore { get; set; }
    public int? GuestScore { get; set; }
    public int Time { get; set; }

    public bool IsAvailable { get; set; } = true;

    public BoardSize BoardSize { get; set; }
}
