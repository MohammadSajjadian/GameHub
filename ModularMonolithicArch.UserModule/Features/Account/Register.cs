using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModularMonolithicArch.UserModule.Features.Account;

public static class Register
{
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

    public record RegisterRequest(RegisterDto RegisterDto) : IRequest<IdentityResult>;

    internal class RegisterRequestHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<RegisterRequest, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> userManager = userManager;

        public async Task<IdentityResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Email = request.RegisterDto.Email,
                UserName = request.RegisterDto.Email,
                EmailConfirmed = true
            };

            return await userManager.CreateAsync(user, request.RegisterDto.Password);
        }
    }
}
