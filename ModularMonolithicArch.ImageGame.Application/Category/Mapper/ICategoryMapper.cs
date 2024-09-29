using ModularMonolithicArch.ImageGame.Application.Category.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Category.Mapper;

public interface ICategoryMapper
{
    Domain.Entities.Category Map(CategoryDto categoryDto);
}
