using ModularMonolithicArch.ImageGame.Domain.Base;

namespace ModularMonolithicArch.ImageGame.Domain.Entities;

public class Category : CategoryBase
{
    public ICollection<Room> Rooms { get; set; } = default!;
    public ICollection<Image> Images { get; set; } = default!;
}
