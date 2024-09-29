using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Category.Mapper;

public class CategoryMapper : ICategoryMapper
{
    public Domain.Entities.Category Map(CategoryDto categoryDto)
        => new()
        {
            Name = categoryDto.Name
        };
}
