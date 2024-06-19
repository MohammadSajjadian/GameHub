using GameHub.Application.Category.Dto;

namespace GameHub.Application.Category.Mapper;

public class CategoryMapper : ICategoryMapper
{
    public Domain.Entities.Category Map(CategoryDto categoryDto)
    {
        return new Domain.Entities.Category
        {
            Name = categoryDto.Name
        };
    }
}
