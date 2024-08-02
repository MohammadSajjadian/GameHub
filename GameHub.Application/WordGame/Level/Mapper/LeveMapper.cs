using GameHub.Application.WordGame.Level.Dto;

namespace GameHub.Application.WordGame.Level.Mapper;

public class LeveMapper : ILeveMapper
{
    public Domain.Entities.WordGame.Level Map(LevelDto levelDto)
    {
        return new Domain.Entities.WordGame.Level
        {
            LevelNumber = levelDto.LevelNumber,
            Word = levelDto.Word.ToLower(),
            Hint = levelDto.Hint,
            CategoryId = levelDto.CategoryDto.Id,
            LevelStatus = levelDto.LevelStatus
        };
    }
}
