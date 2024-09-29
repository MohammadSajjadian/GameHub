using ModularMonolithicArch.WordGame.Domain.Core;

namespace ModularMonolithicArch.WordGame.Domain.Repository;

public interface ILetterService
{
    void MarkAsDisable(Letter letter);
    void MarkAsCorrect(Letter letter);
}
