using GameHub.Domain.Core.WordGame;

namespace GameHub.Domain.Repository.WordGame;

public interface IWordService
{
    List<int> RemoveRandomLetters(Word word, int percentageOfCharsToHide);
    void DisableRemainingLetters(Word word, List<int> randomIndices);
    void ClearLettersAtRandomIndices(Word word, List<int> randomIndices);
    void MakeLettersGreen(Word word, string insertedLetter, List<int> randomIndices);
    bool IsEmptyLetterExist(Word word);
}
