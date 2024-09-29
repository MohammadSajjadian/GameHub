using ModularMonolithicArch.WordGame.Application.Category.Dto;

namespace ModularMonolithicArch.WordGame.Application.Category.Mapper;

public interface ICategoryMapper
{
    Domain.Entities.Category Map(CategoryDto categoryDto);
}
