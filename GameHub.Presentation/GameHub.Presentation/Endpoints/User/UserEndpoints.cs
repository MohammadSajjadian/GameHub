using GameHub.Application.User.Repository;

namespace GameHub.Presentation.Endpoints.User;

public static class UserEndpoints
{
    public static async Task<IResult> GetUserAsync(string userName, IUserService userService)
    {
        var user = await userService.GetUserAsync(userName);
        return user is not null ? Results.Ok(user) : Results.BadRequest("Can't find user.");
    }

    public static async Task<IResult> UpdateHealthAsync(string userName, IUserService userService)
    {
        int result = await userService.UpdateHealthAsync(userName);
        return result == 1 ? Results.Ok() : Results.BadRequest("Can't update user health.");
    }
}
