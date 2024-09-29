using ModularMonolithicArch.ImageGame.Application.Image.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Image.Mapper;

public class ImageMapper : IImageMapper
{
    public Domain.Entities.Image Map(ImageDto imageDto)
        => new()
        {
            CategoryId = imageDto.CategoryDto.Id,
        };
}
