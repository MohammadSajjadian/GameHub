using ModularMonolithicArch.WordGame.Application.Level.Dto;

namespace ModularMonolithicArch.WordGame.Application.Level.Mapper;

public class LeveMapper : ILeveMapper
{
    public Domain.Entities.Level Map(LevelDto levelDto)
        => new()
        {
            LevelNumber = levelDto.LevelNumber,
            Word = levelDto.Word.ToLower(),
            Hint = levelDto.Hint,
            CategoryId = levelDto.CategoryDto.Id,
            LevelStatus = levelDto.LevelStatus
        };
}
