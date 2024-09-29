using ModularMonolithicArch.ImageGame.Application.Room.Dto;

namespace ModularMonolithicArch.ImageGame.Application.Room.Mapper;

public interface IRoomMapper
{
    Domain.Entities.Room Map(RoomDto roomDto, string id);
}
