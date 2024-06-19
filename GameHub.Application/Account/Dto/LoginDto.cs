using System.ComponentModel.DataAnnotations;

namespace GameHub.Application.Account.Dto;

public class LoginDto
{
    [Required] public string Email { get; set; } = default!;
    [Required] public string Password { get; set; } = default!;

    public bool RememberMe { get; set; }
}
