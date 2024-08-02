using GameHub.Application.User.Dto;
using GameHub.Application.User.Mapper;
using GameHub.Application.User.Repository;
using GameHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GameHub.Infra.Services.User;

public class UserService(UserManager<ApplicationUser> userManager, IUserMapper mapper, IHttpContextAccessor httpContextAccessor) : IUserService
{
    public async Task<ApplicationUserDto?> GetUserAsync(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return null;

        var user = await userManager.FindByNameAsync(userName);

        if (user is null)
            return null;

        return mapper.Map(user);
    }

    public async Task<ApplicationUserDto> GetCurrentUserAsync()
    {
        var user = await userManager.FindByNameAsync(httpContextAccessor.HttpContext.User.Identity!.Name!);
        return mapper.Map(user!);
    }

    public async Task<string> GetUserIdAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        return user!.Id;
    }

    public async Task<int> UpdateHealthAsync(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            return 0;

        var user = await userManager.FindByNameAsync(userName);
        if (user is null)
            return 0;

        try
        {
            user.Health--;
            await userManager.UpdateAsync(user);
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}
