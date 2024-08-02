using GameHub.Application.ImageGame.Category.Dto;

namespace GameHub.Application.ImageGame.Image.Dto;

public class ImageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public CategoryDto CategoryDto { get; set; } = new();
}
