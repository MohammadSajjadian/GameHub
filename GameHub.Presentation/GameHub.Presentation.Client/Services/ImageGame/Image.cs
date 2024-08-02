
namespace GameHub.Presentation.Client.Services.ImageGame;

public class Image
{
    private bool _isVisible;

    public int Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool IsVisible => _isVisible;

    public void MarkAsVisible()
        => _isVisible = true;

    public void MarkAsInVisible()
        => _isVisible = false;
}
