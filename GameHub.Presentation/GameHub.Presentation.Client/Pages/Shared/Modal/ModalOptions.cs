namespace GameHub.Presentation.Client.Pages.Shared.Modal;

public class ModalOptions
{
    public string? Text { get; set; }
    public string? Title { get; set; }
    /// <summary>
    /// From 1 to 6
    /// </summary>
    public int TextSize { get; set; }

    public bool ShowConfirmButton { get; set; }
    public string? ConfirmButtonText { get; set; }
    public string? ConfirmButtonColor { get; set; }
    public bool ShowDenyButton { get; set; }
    public string? DenyButtonText { get; set; }
    public string? DenyButtonColor { get; set; }

    public bool AllowOutsideClick { get; set; }
}
