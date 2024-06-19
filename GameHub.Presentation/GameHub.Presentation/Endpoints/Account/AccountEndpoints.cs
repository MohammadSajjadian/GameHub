using GameHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.Presentation.Endpoints.Account;

public static class AccountEndpoints
{
    public static async Task<IResult> LogOutAsync(SignInManager<ApplicationUser> signInManager, [FromForm] string returnUrl)
    {
        await signInManager.SignOutAsync();
        return Results.LocalRedirect($"~/{returnUrl}");
    }
}
