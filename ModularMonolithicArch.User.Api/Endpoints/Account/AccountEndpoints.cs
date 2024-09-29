using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;

namespace ModularMonolithicArch.User.Api.Endpoints.Account;

public static class AccountEndpoints
{
    public static async Task<IResult> LogOutAsync(SignInManager<ApplicationUser> signInManager, [FromForm] string returnUrl)
    {
        await signInManager.SignOutAsync();
        return Results.LocalRedirect($"~/{returnUrl}");
    }
}
