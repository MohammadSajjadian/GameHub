using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.ImageGame.Application.Room.Dto;
using ModularMonolithicArch.ImageGame.Application.Room.Mapper;
using ModularMonolithicArch.ImageGame.Application.Room.Repository;
using ModularMonolithicArch.ImageGame.Infrastructure.Context;
using ModularMonolithicArch.User.Contract.Messages.Queries;

namespace ModularMonolithicArch.ImageGame.Infrastructure.Services;

public class RoomService(ImageGameContext db, IMediator mediator, IRoomMapper mapper) : IRoomService
{
    public async Task<int> CreateAsync(RoomDto roomDto, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetCurrentUserRequest(), cancellationToken);

        bool isRoomExist = await IsRoomExistAndAvailable(user.Id);
        if (isRoomExist) return 0;

        var room = mapper.Map(roomDto, user.Id);

        db.Add(room);
        await db.SaveChangesAsync(cancellationToken);

        return room.Id;
    }


    public async Task<int> AddGuestToRoom(int roomId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetCurrentUserRequest(), cancellationToken);

        return await db.Rooms
            .Where(r => r.Id == roomId)
            .ExecuteUpdateAsync(r => r
            .SetProperty(p => p.GuestId, user.Id)
            .SetProperty(p => p.GuestUserName, user.UserName)
            .SetProperty(p => p.IsAvailable, false), cancellationToken);
    }


    public async Task<int> DeleteAsync(int id, CancellationToken cancellationToken)
        => await db.Rooms
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync(cancellationToken);


    public async Task<List<RoomDto>?> GetAllAsync(CancellationToken cancellationToken)
        => await db.Rooms
        .AsNoTracking()
        .Where(r => r.IsAvailable)
        .OrderByDescending(r => r.Id)
        .Select(r => new RoomDto
        {
            Id = r.Id,
            CategoryId = r.CategoryId,
            CategoryName = r.Category.Name,
            CreatorId = r.CreatorId,
            CreatorUserName = r.CreatorUserName,
            GuestId = r.GuestId!,
            GuestUserName = r.GuestUserName!,
            CreatorConnectionId = r.ConnectionId,
            Time = r.Time,
            BoardSize = r.BoardSize,
        }).ToListAsync(cancellationToken);


    public async Task<RoomDto?> GetAsync(int id, CancellationToken cancellationToken)
        => await db.Rooms
            .AsNoTracking()
            .Where(r => r.Id == id)
            .Select(r => new RoomDto
            {
                Id = r.Id,
                CategoryId = r.CategoryId,
                CreatorId = r.CreatorId,
                CreatorUserName = r.CreatorUserName,
                GuestId = r.GuestId!,
                GuestUserName = r.GuestUserName!,
                Time = r.Time,
                BoardSize = r.BoardSize,
            })
        .FirstOrDefaultAsync(cancellationToken);


    public async Task<bool> IsRoomExistAndAvailable(string creatorId)
        => await db.Rooms.AnyAsync(r => r.CreatorId == creatorId && r.IsAvailable);


    public async Task<int> DeleteCurrentUserRoomsAsync(string userName)
        => await db.Rooms
        .Where(r => r.CreatorUserName == userName && r.IsAvailable)
        .ExecuteDeleteAsync();


    public async Task<int> UpdateScoresAsync(int id, int creatorScore, int guestScore, CancellationToken cancellationToken)
        => await db.Rooms
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(r => r
            .SetProperty(p => p.CreatorScore, creatorScore)
            .SetProperty(p => p.GuestScore, guestScore), cancellationToken);
}
