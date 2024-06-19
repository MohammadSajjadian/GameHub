using GameHub.Application.Category.Dto;

namespace GameHub.Application.Category.Mapper;

public interface ICategoryMapper
{
    Domain.Entities.Category Map(CategoryDto categoryDto);
}
