using GameHub.Application.User.Dto;
using GameHub.Application.User.Mapper;
using GameHub.Application.User.Repository;
using GameHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GameHub.Infra.Services.User;

public class UserService(UserManager<ApplicationUser> userManager, IUserMapper mapper) : IUserService
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
