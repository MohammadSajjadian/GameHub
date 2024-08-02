using GameHub.Application.User.Dto;

namespace GameHub.Application.User.Repository;

public interface IUserService
{
    Task<ApplicationUserDto?> GetUserAsync(string userName);
    Task<ApplicationUserDto> GetCurrentUserAsync();
    Task<string> GetUserIdAsync(string userName);
    Task<int> UpdateHealthAsync(string userName);
}
