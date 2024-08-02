using GameHub.Application.WordGame.Category.Dto;

namespace GameHub.Application.WordGame.Category.Mapper;

public interface ICategoryMapper
{
    Domain.Entities.WordGame.Category Map(CategoryDto categoryDto);
}
