using GameHub.Domain.Enums.ImageGame;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Domain.Entities.ImageGame;

public class Room
{
    public int Id { get; set; }

    public int CategoryId { get; set; } = default!;
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = default!;
    
    public string CreatorId { get; set; } = default!;
    [ForeignKey(nameof(CreatorId))]
    public ApplicationUser ApplicationUser { get; set; } = default!;

    public string? GuestUserName { get; set; }
    public string ConnectionId { get; set; } = default!;

    public int? CreatorScore { get; set; }
    public int? GuestScore { get; set; }
    public int Time { get; set; }

    public bool IsAvailable { get; set; } = true;

    public BoardSize BoardSize { get; set; }
}
