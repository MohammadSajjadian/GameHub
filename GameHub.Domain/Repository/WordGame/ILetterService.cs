using GameHub.Domain.Core.WordGame;

namespace GameHub.Domain.Repository.WordGame;

public interface ILetterService
{
    void MarkAsDisable(Letter letter);
    void MarkAsCorrect(Letter letter);
}
