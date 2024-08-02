using GameHub.Application.ImageGame.Room.Dto;
using Microsoft.AspNetCore.SignalR;

namespace GameHub.Presentation.Hubs;

public class RoomHub : Hub<IRoomHub>
{
    private const string _groupName = "roomGroup";

    public async Task AddRoomAsync(RoomDto roomDto)
        => await Clients.All.ReceiveAddRoomMessage(roomDto);

    public async Task DeleteRoomAsync(int roomId)
        => await Clients.All.ReceiveDeleteRoomMessage(roomId);

    public async Task GoToRoomAsync(int roomId)
        => await Clients.Group(_groupName).ReceiveGoToRoomMessage(roomId);

    public async Task ManageGroupAsync(string creatorConnectionId, string guestConnectionId)
    {
        await Groups.AddToGroupAsync(creatorConnectionId, _groupName);
        await Groups.AddToGroupAsync(guestConnectionId, _groupName);
    }
}

public interface IRoomHub
{
    Task ReceiveAddRoomMessage(RoomDto roomDto);
    Task ReceiveDeleteRoomMessage(int roomId);
    Task ReceiveGroupMessage(int roomId);
    Task ReceiveGoToRoomMessage(int roomId);
}
