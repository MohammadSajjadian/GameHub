using GameHub.Application.User.Dto;
using GameHub.Domain.Entities;

namespace GameHub.Application.User.Mapper;

public interface IUserMapper
{
    ApplicationUserDto Map(ApplicationUser user);
}
