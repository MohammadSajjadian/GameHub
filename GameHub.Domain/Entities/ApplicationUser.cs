using Microsoft.AspNetCore.Identity;

namespace GameHub.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public int Health { get; set; } = 3;
}
