using GameHub.Domain.Core.WordGame;

namespace GameHub.Domain.Repository.WordGame;

public interface IWordGameService
{
    List<int> RandomIndices { get; }
    bool IsGuideActive { get; }
    string Hint { get; }

    void Initialize(Word word, string hint, int percentageOfCharsToHide);
    bool IsAnswerCorrect();
    void EnableGuide();
}
