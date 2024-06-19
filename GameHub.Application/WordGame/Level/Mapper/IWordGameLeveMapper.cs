using GameHub.Application.WordGame.Level.Dto;
using GameHub.Domain.Entities.WordGame;

namespace GameHub.Application.WordGame.Level.Mapper;

public interface IWordGameLeveMapper
{
    WordGameLevel Map(WordGameLevelDto levelDto);
}
