using ModularMonolithicArch.WordGame.Domain.Core;

namespace ModularMonolithicArch.WordGame.Domain.Repository;

public interface IWordService
{
    List<int> RemoveRandomLetters(Word word, int percentageOfCharsToHide);
    void DisableRemainingLetters(Word word, List<int> randomIndices);
    void ClearLettersAtRandomIndices(Word word, List<int> randomIndices);
    void MakeLettersGreen(Word word, string insertedLetter, List<int> randomIndices);
    bool IsEmptyLetterExist(Word word);
}
