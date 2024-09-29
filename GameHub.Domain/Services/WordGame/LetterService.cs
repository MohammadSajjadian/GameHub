using GameHub.Domain.Core.WordGame;
using GameHub.Domain.Repository.WordGame;

namespace GameHub.Domain.Services.WordGame;

public class LetterService : ILetterService
{
    public void MarkAsDisable(Letter letter)
        => letter.IsDisable = true;

    public void MarkAsCorrect(Letter letter)
        => letter.IsCorrect = true;
}
