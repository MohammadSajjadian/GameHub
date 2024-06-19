using GameHub.Application.WordGame.Level.Dto;
using GameHub.Domain.Entities.WordGame;

namespace GameHub.Application.WordGame.Level.Mapper;

public class WordGameLeveMapper : IWordGameLeveMapper
{
    public WordGameLevel Map(WordGameLevelDto levelDto)
    {
        return new WordGameLevel
        {
            LevelNumber = levelDto.LevelNumber,
            Word = levelDto.Word.ToLower(),
            Hint = levelDto.Hint,
            CategoryId = levelDto.CategoryDto.Id,
            LevelStatus = levelDto.LevelStatus
        };
    }
}
