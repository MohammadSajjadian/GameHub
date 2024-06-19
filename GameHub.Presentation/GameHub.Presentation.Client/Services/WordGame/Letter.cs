namespace GameHub.Presentation.Client.Services.WordGame;

public class Letter
{
    public char Value { get; set; }
    public bool IsDisable { get; private set; }
    public bool IsCorrect { get; private set; }

    public void MarkAsDisable()
        => IsDisable = true;

    public void MarkAsCorrect()
        => IsCorrect = true;
}
