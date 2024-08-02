using GameHub.Application.User.Dto;
using GameHub.Domain.Entities;

namespace GameHub.Application.User.Mapper;

public class UserMapper : IUserMapper
{
    public ApplicationUserDto Map(ApplicationUser user)
    {
        return new ApplicationUserDto
        {
            Id = user.Id,
            UserName = user.UserName!,
            Health = user.Health,
            Coin = user.Coin
        };
    }
}
