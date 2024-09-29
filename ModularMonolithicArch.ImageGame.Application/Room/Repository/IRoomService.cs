using ModularMonolithicArch.ImageGame.Application.Room.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Room.Repository;

public interface IRoomService
{
    Task<int> CreateAsync(RoomDto roomDto, CancellationToken cancellationToken);
    Task<int> AddGuestToRoom(int roomId, CancellationToken cancellationToken);
    Task<int> DeleteCurrentUserRoomsAsync(string userName);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateScoresAsync(int id, int creatorScore, int guestScore, CancellationToken cancellationToken);
    Task<RoomDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<List<RoomDto>?> GetAllAsync(CancellationToken cancellationToken);
}
