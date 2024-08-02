using GameHub.Domain.Enums.ImageGame;

namespace GameHub.Application.ImageGame.Room.Dto;

public class RoomDto
{
    public int Id { get; set; }

    public string CreatorId { get; set; } = default!;
    public string CreatorUserName { get; set; } = default!;
    public string CreatorConnectionId { get; set; } = default!;
    public string GuestId { get; set; } = default!;
    public string GuestUserName { get; set; } = default!;
    public string CategoryName { get; set; } = default!;

    public int CategoryId { get; set; }
    public int Time { get; set; }
    public int CreatorScore { get; set; }
    public int GuestScore { get; set; }

    public BoardSize BoardSize { get; set; }
}
