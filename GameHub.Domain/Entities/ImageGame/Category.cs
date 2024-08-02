using GameHub.Domain.Entities.Base;

namespace GameHub.Domain.Entities.ImageGame;

public class Category : CategoryBase
{
    public ICollection<Room> Rooms { get; set; } = default!;
    public ICollection<Image> Images { get; set; } = default!;
}
