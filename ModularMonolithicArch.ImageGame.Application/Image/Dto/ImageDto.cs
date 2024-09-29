using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Image.Dto;

public class ImageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public CategoryDto CategoryDto { get; set; } = new();
}
