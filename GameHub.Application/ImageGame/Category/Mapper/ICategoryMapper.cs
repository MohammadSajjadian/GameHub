using GameHub.Application.ImageGame.Category.Dto;
using GameHub.Domain.Entities.ImageGame;

namespace GameHub.Application.ImageGame.Category.Mapper;

public interface ICategoryMapper
{
    Domain.Entities.ImageGame.Category Map(CategoryDto categoryDto);
}
