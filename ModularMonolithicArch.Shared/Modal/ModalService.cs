using Microsoft.JSInterop;

namespace ModularMonolithicArch.Shared.Modal;

public class ModalService(IJSRuntime jSRuntime) : IAsyncDisposable
{
    private IJSObjectReference jsObjectReference = default!;
    private TaskCompletionSource<bool> tcs = default!;
    private readonly ModalResult modalResult = new();
    public ModalOptions modalOptions = new();
    public event EventHandler<EventArgs>? OnFire;

    public async Task InitializeAsync()
        => jsObjectReference = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/ModularMonolithicArch.Shared/CustomJs/Modal.js");

    public async Task<ModalResult> FireAsync(ModalOptions configure)
    {
        await Task.Delay(250);
        modalOptions = configure;
        OnFire?.Invoke(this, new EventArgs());
        await Show();

        return modalResult;
    }

    public async void ConfirmButton()
    {
        modalResult.IsConfirmed = true;
        await Hide();
        modalResult.IsConfirmed = false;
    }

    public async void DenyButton()
    {
        modalResult.IsDenied = true;
        await Hide();
        modalResult.IsDenied = false;
    }

    private async Task Show()
    {
        tcs = new TaskCompletionSource<bool>();
        await jsObjectReference.InvokeVoidAsync("Show");
        await tcs.Task;
        Console.WriteLine("Show called.");
    }

    private async Task Hide()
    {
        await jsObjectReference.InvokeVoidAsync("Hide");
        tcs.SetResult(true);
    }

    public async ValueTask DisposeAsync()
    {
        if (jsObjectReference is not null)
        {
            await jsObjectReference.DisposeAsync();
        }
    }
}
