using GameHub.Application.User.Dto;
using GameHub.Domain.Entities;

namespace GameHub.Application.User.Mapper;

public class UserMapper : IUserMapper
{
    public ApplicationUserDto Map(ApplicationUser user)
    {
        return new ApplicationUserDto
        {
            Health = user.Health,
            Coin = user.Coin
        };
    }
}
