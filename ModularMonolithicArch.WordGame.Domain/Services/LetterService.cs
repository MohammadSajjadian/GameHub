using ModularMonolithicArch.WordGame.Domain.Core;
using ModularMonolithicArch.WordGame.Domain.Repository;

namespace ModularMonolithicArch.WordGame.Domain.Services;

public class LetterService : ILetterService
{
    public void MarkAsDisable(Letter letter)
        => letter.IsDisable = true;

    public void MarkAsCorrect(Letter letter)
        => letter.IsCorrect = true;
}
