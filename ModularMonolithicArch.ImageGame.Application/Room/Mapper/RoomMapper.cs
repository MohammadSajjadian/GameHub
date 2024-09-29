using ModularMonolithicArch.ImageGame.Application.Room.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Room.Mapper;

public class RoomMapper : IRoomMapper
{
    public Domain.Entities.Room Map(RoomDto roomDto, string id)
    {
        return new()
        {
            Id = roomDto.Id,
            CreatorId = id,
            CreatorUserName = roomDto.CreatorUserName,
            CategoryId = roomDto.CategoryId,
            ConnectionId = roomDto.CreatorConnectionId,
            Time = roomDto.Time,
            BoardSize = roomDto.BoardSize,
        };
    }
}
