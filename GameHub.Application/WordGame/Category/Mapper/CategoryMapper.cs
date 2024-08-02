using GameHub.Application.WordGame.Category.Dto;

namespace GameHub.Application.WordGame.Category.Mapper;

public class CategoryMapper : ICategoryMapper
{
    public Domain.Entities.WordGame.Category Map(CategoryDto categoryDto)
    {
        return new Domain.Entities.WordGame.Category
        {
            Name = categoryDto.Name
        };
    }
}
