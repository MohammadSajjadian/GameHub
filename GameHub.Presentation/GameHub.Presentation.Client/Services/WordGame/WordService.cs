namespace GameHub.Presentation.Client.Services.WordGame;

public class WordService
{
    private string hint = string.Empty;
    private List<int> copyRandomIndices = [];

    public string Value { get; private set; } = default!;
    public int PercentageOfCharsToHide { get; private set; } = default!;
    public bool IsGuideActive { get; private set; }
    public List<Letter> Letters { get; set; } = [];


    public void Initialize(string value, string hint, int percentageOfCharsToHide)
    {
        Value = value;
        this.hint = hint;
        Letters = value.Select(v => new Letter { Value = v }).ToList();

        RemoveRandomLetters(percentageOfCharsToHide);
        DisableRemainingLetters();
    }

    public bool IsAnswerCorrect()
    {
        string insertedLetter = string.Join("", Letters.Select(l => l.Value));

        if (IsGuideActive)
            MakeLettersGreen(insertedLetter);

        return Equals(insertedLetter, Value);
    }

    public void ActivateGuide()
        => IsGuideActive = true;

    public void ClearLettersAtRandomIndices()
    {
        copyRandomIndices.ForEach(r =>
        {
            Letters[r].Value = '\0';
        });
    }

    private void RemoveRandomLetters(int percentageOfCharsToHide)
    {
        int deletedLetters = Value.Length * percentageOfCharsToHide / 100;

        List<int> randomIndices = Enumerable
            .Range(0, Value.Length - 1)
            .OrderBy(x => Random.Shared.Next())
            .Take(deletedLetters)
            .ToList();

        randomIndices.ForEach(r =>
        {
            Letters[r].Value = '\0';
        });

        copyRandomIndices = randomIndices;
    }

    private void MakeLettersGreen(string insertedLetter)
    {
        copyRandomIndices.ForEach(r =>
        {
            if (Equals(insertedLetter[r], Value[r]))
            {
                Letters[r].MarkAsCorrect();
            }
        });
    }

    private void DisableRemainingLetters()
    {
        Letters.Where((letter, index) => !copyRandomIndices.Contains(index))
            .ToList()
            .ForEach(letter => letter.MarkAsDisable());
    }

    public string GetHint()
        => hint;
}
