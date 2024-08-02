using GameHub.Application.ImageGame.Image.Dto;
using GameHub.Domain.Entities.ImageGame;

namespace GameHub.Application.ImageGame.Image.Mapper;

public interface IImageMapper
{
    Domain.Entities.ImageGame.Image Map(ImageDto imageDto);
}
