using ModularMonolithicArch.ImageGame.Application.Image.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Image.Mapper;

public interface IImageMapper
{
    Domain.Entities.Image Map(ImageDto imageDto);
}
