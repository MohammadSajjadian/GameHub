using Blazored.LocalStorage;
using GameHub.Application.User.Queries.Requests;
using MediatR;

namespace GameHub.Presentation.Client.Services.WordGame;

public class HealthService(IMediator mediator, ILocalStorageService localStorage)
{
    public const int maxLocalHealth = 3;

    public int Value { get; private set; } = default!;

    public async Task<int> GetProfileHealthAsync(string userName)
    {
        await localStorage.RemoveItemAsync("Health");
        var getUseResponse = await mediator.Send(new GetUserRequest(userName));
        Value = getUseResponse.UserDto!.Health;
        
        return getUseResponse.UserDto!.Health;
    }

    public async Task<int?> GetLocalHealthAsync()
    {
        int? localHealth = await localStorage.GetItemAsync<int?>("Health");
        if (localHealth is null)
        {
            Value = maxLocalHealth;
            await localStorage.SetItemAsync("Health", Value);
        }
        if (localHealth.HasValue && localHealth.Value != 0)
        {
            Value = localHealth.Value;
        }

        return localHealth;
    }

    public async Task PreventChangeLocalHealthAsync()
    {
        Value = maxLocalHealth;
        await localStorage.SetItemAsync("Health", 2);
    }

    public async Task ReduceFromProfileAsync(string userName)
    {
        Value--;
        await mediator.Send(new ReduceHealthRequest(userName!));
    }

    public async Task ReduceFromLocalAsync()
    {
        Value--;
        await localStorage.SetItemAsync("Health", Value);
    }
}
