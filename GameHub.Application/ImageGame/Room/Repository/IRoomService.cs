using GameHub.Application.ImageGame.Room.Dto;

namespace GameHub.Application.ImageGame.Room.Repository;

public interface IRoomService
{
    Task<int> CreateAsync(RoomDto roomDto, CancellationToken cancellationToken);
    Task<int> AddGuestToRoom(int roomId, string guestUserName, CancellationToken cancellationToken);
    Task<int> DeleteCurrentUserRoomsAsync(string userName);
    Task<int> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<int> UpdateScoresAsync(int id, int creatorScore, int guestScore, CancellationToken cancellationToken);
    Task<RoomDto?> GetAsync(int id, CancellationToken cancellationToken);
    Task<List<RoomDto>?> GetAllAsync(CancellationToken cancellationToken);
}
