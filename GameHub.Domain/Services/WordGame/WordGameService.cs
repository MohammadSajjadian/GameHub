using GameHub.Domain.Core.WordGame;
using GameHub.Domain.Repository.WordGame;

namespace GameHub.Domain.Services.WordGame;

public class WordGameService(IWordService wordService) : IWordGameService
{
    private List<int> _randomIndices = [];
    private Word _word = new();
    private bool _isGuideActive;
    private string _hint = string.Empty;

    public List<int> RandomIndices => _randomIndices;
    public bool IsGuideActive => _isGuideActive;
    public string Hint => _hint;

    public void Initialize(Word word, string hint, int percentageOfCharsToHide)
    {
        _word = word;
        _word.Letters = word.Value.Select(v => new Letter { Value = v }).ToList();
        _hint = hint;

        _randomIndices = wordService.RemoveRandomLetters(word, percentageOfCharsToHide);
        wordService.DisableRemainingLetters(word, _randomIndices);
    }

    public bool IsAnswerCorrect()
    {
        string insertedLetter = string.Join("", _word.Letters.Select(l => l.Value));

        if (IsGuideActive)
            wordService.MakeLettersGreen(_word, insertedLetter, _randomIndices);

        return Equals(insertedLetter, _word.Value);
    }

    public void EnableGuide()
        => _isGuideActive = true;
}
