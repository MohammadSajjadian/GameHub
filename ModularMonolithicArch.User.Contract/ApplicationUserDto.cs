namespace ModularMonolithicArch.User.Contract;

public class ApplicationUserDto
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int Health { get; set; }
}
