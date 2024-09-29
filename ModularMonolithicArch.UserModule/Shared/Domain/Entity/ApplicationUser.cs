using Microsoft.AspNetCore.Identity;

namespace ModularMonolithicArch.UserModule.Shared.Domain.Entity;

public class ApplicationUser : IdentityUser
{
    public int Health { get; set; } = 3;
}
