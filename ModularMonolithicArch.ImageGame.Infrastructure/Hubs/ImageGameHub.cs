using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ModularMonolithicArch.ImageGame.Infrastructure.Hubs;

[Authorize]
public class ImageGameHub : Hub<IImageGameHub>
{
    public async Task SendProcessImageMessageAsync(string creatorId, string guestId, int imageId)
    {
        await Clients.Users(creatorId, guestId).ReceiveProcessImageMessage(imageId);
    }

    public async Task SendDisconnectedMessageAsync(string userId)
    {
        await Clients.User(userId).ReceiveDisconnectedMessage();
    }
}

public interface IImageGameHub
{
    Task ReceiveProcessImageMessage(int imageId);
    Task ReceiveDisconnectedMessage();
}
