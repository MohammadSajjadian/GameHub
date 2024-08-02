using GameHub.Application.ImageGame.Image.Dto;

namespace GameHub.Application.ImageGame.Image.Mapper;

public class ImageMapper : IImageMapper
{
    public Domain.Entities.ImageGame.Image Map(ImageDto imageDto)
        => new()
        {
            CategoryId = imageDto.CategoryDto.Id,
        };
}
