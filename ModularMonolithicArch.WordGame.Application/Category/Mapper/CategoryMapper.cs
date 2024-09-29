using ModularMonolithicArch.WordGame.Application.Category.Dto;

namespace ModularMonolithicArch.WordGame.Application.Category.Mapper;

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
