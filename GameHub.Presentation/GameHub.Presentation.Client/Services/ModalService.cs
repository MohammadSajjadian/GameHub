using GameHub.Presentation.Client.Pages.Shared.Modal;
using Microsoft.JSInterop;

namespace GameHub.Presentation.Client.Services;

public class ModalService(IJSRuntime jSRuntime) : IAsyncDisposable
{
    private IJSObjectReference jSObjectReference = default!;
    private TaskCompletionSource<bool> tcs = default!;
    private readonly ModalResult modalResult = new();
    public ModalOptions modalOptions = new();
    public event Action? OnChange;

    public async Task InitializeAsync()
        => jSObjectReference = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "./CustomJs/Modal.js");

    public async Task<ModalResult> FireAsync(ModalOptions configure)
    {
        modalOptions = configure;
        OnChange?.Invoke();
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
        await jSObjectReference.InvokeVoidAsync("Show");
        await tcs.Task;
    }

    private async Task Hide()
    {
        await jSObjectReference.InvokeVoidAsync("Hide");
        tcs.SetResult(true);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (jSObjectReference is not null)
        {
            await jSObjectReference.DisposeAsync();
        }
    }
}
