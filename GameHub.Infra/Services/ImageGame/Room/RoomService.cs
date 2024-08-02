using GameHub.Application.ImageGame.Room.Dto;
using GameHub.Application.ImageGame.Room.Mapper;
using GameHub.Application.ImageGame.Room.Repository;
using GameHub.Application.User.Repository;
using GameHub.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Infra.Services.ImageGame.Room;

public class RoomService(GameContext db, IRoomMapper mapper, IUserService userService) : IRoomService
{
    public async Task<int> CreateAsync(RoomDto roomDto, CancellationToken cancellationToken)
    {
        var room = await mapper.Map(roomDto);

        bool isRoomExist = await IsRoomExistAndAvailable(room.CreatorId);
        if (isRoomExist) return 0;

        db.Add(room);
        await db.SaveChangesAsync(cancellationToken);

        return room.Id;
    }


    public async Task<int> AddGuestToRoom(int roomId, string guestUserName, CancellationToken cancellationToken)
        => await db.ImageGameRooms
            .Where(r => r.Id == roomId)
            .ExecuteUpdateAsync(r => r
            .SetProperty(p => p.GuestUserName, guestUserName)
            .SetProperty(p => p.IsAvailable, false), cancellationToken);


    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        => await db.ImageGameRooms
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync(cancellationToken);


    public async Task<List<RoomDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.ImageGameRooms
        .AsNoTracking()
        .Where(r => r.IsAvailable == true)
        .OrderByDescending(r => r.Id)
        .Select(r => new RoomDto
        {
            Id = r.Id,
            CategoryId = r.CategoryId,
            BoardSize = r.BoardSize,
            Time = r.Time,
            CreatorUserName = r.ApplicationUser.UserName!,
            CreatorConnectionId = r.ConnectionId,
            CategoryName = r.Category.Name
        })
        .ToListAsync(cancellationToken);


    public async Task<RoomDto?> GetAsync(int id, CancellationToken cancellationToken)
    {
        var room = await db.ImageGameRooms
            .AsNoTracking()
            .Include(x => x.ApplicationUser)
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (room != null)
        {
            var guestId = await userService.GetUserIdAsync(room.GuestUserName!);
            return new RoomDto
            {
                Id = room.Id,
                CategoryId = room.CategoryId,
                CreatorId = room.CreatorId,
                CreatorUserName = room.ApplicationUser.UserName!,
                GuestUserName = room.GuestUserName!,
                GuestId = guestId,
                Time = room.Time,
                BoardSize = room.BoardSize,
            };
        }
        return null;
    }


    public async Task<bool> IsRoomExistAndAvailable(string creatorId)
        => await db.ImageGameRooms.AnyAsync(r => r.CreatorId == creatorId && r.IsAvailable == true);


    public async Task<int> DeleteCurrentUserRoomsAsync(string userName)
    {
        var user = await userService.GetUserAsync(userName);

        return await db.ImageGameRooms
            .Where(r => r.CreatorId == user!.Id && r.IsAvailable == true)
            .ExecuteDeleteAsync();
    }

    public async Task<int> UpdateScoresAsync(int id, int creatorScore, int guestScore, CancellationToken cancellationToken)
        => await db.ImageGameRooms
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(r => r
            .SetProperty(p => p.CreatorScore, creatorScore)
            .SetProperty(p => p.GuestScore, guestScore), cancellationToken);
}
