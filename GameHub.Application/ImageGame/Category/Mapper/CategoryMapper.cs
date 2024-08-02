using GameHub.Application.ImageGame.Category.Dto;

namespace GameHub.Application.ImageGame.Category.Mapper;

public class CategoryMapper : ICategoryMapper
{
    public Domain.Entities.ImageGame.Category Map(CategoryDto categoryDto)
        => new()
        {
            Name = categoryDto.Name
        };
}
