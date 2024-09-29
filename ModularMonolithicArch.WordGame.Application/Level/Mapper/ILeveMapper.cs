using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Mapper;

public interface ILeveMapper
{
    Domain.Entities.Level Map(LevelDto levelDto);
}
