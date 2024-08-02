using GameHub.Application.ImageGame.Room.Dto;
using GameHub.Application.User.Repository;

namespace GameHub.Application.ImageGame.Room.Mapper;

public class RoomMapper(IUserService service) : IRoomMapper
{
    public async Task<Domain.Entities.ImageGame.Room> Map(RoomDto roomDto)
    {
        var user = await service.GetCurrentUserAsync();
        return new Domain.Entities.ImageGame.Room
        {
            Id = roomDto.Id,
            CreatorId = user.Id,
            CategoryId = roomDto.CategoryId,
            ConnectionId = roomDto.CreatorConnectionId,
            Time = roomDto.Time,
            BoardSize = roomDto.BoardSize,
        };
    }
}
