using GameHub.Application.ImageGame.Room.Dto;

namespace GameHub.Application.ImageGame.Room.Mapper;

public interface IRoomMapper
{
    Task<Domain.Entities.ImageGame.Room> Map(RoomDto roomDto);
}
