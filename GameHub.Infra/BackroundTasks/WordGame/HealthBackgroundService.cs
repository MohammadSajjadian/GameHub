using GameHub.Domain.Entities;
using GameHub.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace GameHub.Infra.BackroundTasks.WordGame;

public class HealthBackgroundService(IServiceProvider sp) : IHostedService, IAsyncDisposable
{
    private Timer? timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        timer = new(IncreaseHealth, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        return Task.CompletedTask;
    }

    public async void IncreaseHealth(object? state)
    {
        CancellationTokenSource cts = new();

        using var scope = sp.CreateScope();
        var service = scope.ServiceProvider;
        var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
        var db = service.GetRequiredService<GameContext>();

        await userManager.Users
            .Where(u => u.Health < 3)
            .ForEachAsync(u => u.Health++, cts.Token);
        await db.SaveChangesAsync(cts.Token);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if (timer is IAsyncDisposable _timer)
        {
            await _timer.DisposeAsync();
        }

        timer = null;
    }
}
