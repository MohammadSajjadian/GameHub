using ModularMonolithicArch.WordGame.Domain.Core;
using ModularMonolithicArch.WordGame.Domain.Repository;

namespace ModularMonolithicArch.WordGame.Domain.Services;

public class WordService(ILetterService letterService) : IWordService
{
    public List<int> RemoveRandomLetters(Word word, int percentageOfCharsToHide)
    {
        int deletedLettersCount = word.Value.Length * percentageOfCharsToHide / 100;

        List<int> randomIndices = GetRandomIndices(word.Value.Length, deletedLettersCount);

        randomIndices.ForEach(r =>
        {
            word.Letters[r].Value = '\0';
        });

        return randomIndices;
    }


    private static List<int> GetRandomIndices(int length, int deletedLettersCount)
        => Enumerable
            .Range(0, length - 1)
            .OrderBy(x => Random.Shared.Next())
            .Take(deletedLettersCount)
            .ToList();


    public void DisableRemainingLetters(Word word, List<int> randomIndices)
        => word.Letters.Where((letter, index) => !randomIndices.Contains(index))
        .ToList()
        .ForEach(letterService.MarkAsDisable);


    public void ClearLettersAtRandomIndices(Word word, List<int> randomIndices)
    {
        randomIndices.ForEach(r =>
        {
            word.Letters[r].Value = '\0';
        });
    }


    public void MakeLettersGreen(Word word, string insertedLetter, List<int> randomIndices)
    {
        randomIndices.ForEach(r =>
        {
            if (Equals(insertedLetter[r], word.Value[r]))
            {
                letterService.MarkAsCorrect(word.Letters[r]);
            }
        });
    }

    public bool IsEmptyLetterExist(Word word)
        => word.Letters.Any(l => l.Value == '\0');
}
