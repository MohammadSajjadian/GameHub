using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModularMonolithicArch.User.Contract.Messages.Commands;

namespace ModularMonolithicArch.WordGame.Infrastructure.BackroundTasks;

public class HealthBackgroundService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

            using var scope = serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            _ = await mediator.Send(new IncreaseUsersHealthRequest(), stoppingToken);
        }
    }
}
