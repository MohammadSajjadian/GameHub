namespace GameHub.Application.User.Dto;

public class ApplicationUserDto
{
    public string Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public int Health { get; set; }
    public int Coin { get; set; }
}
