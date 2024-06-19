using System.ComponentModel.DataAnnotations;

namespace GameHub.Application.Account.Dto;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required] public string Password { get; set; } = default!;

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = default!;
}
