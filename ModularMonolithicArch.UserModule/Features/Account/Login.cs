using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace ModularMonolithicArch.UserModule.Features.Account;

public static class Login
{
    public class LoginDto
    {
        [Required] public string Email { get; set; } = default!;
        [Required] public string Password { get; set; } = default!;

        public bool RememberMe { get; set; }
    }

    public record LoginRequest(LoginDto LoginDto) : IRequest<SignInResult>;

    internal class LoginRequestHandler(SignInManager<ApplicationUser> signInManager) : IRequestHandler<LoginRequest, SignInResult>
    {
        private readonly SignInManager<ApplicationUser> signInManager = signInManager;

        public async Task<SignInResult> Handle(LoginRequest request, CancellationToken cancellationToken)
            => await signInManager.PasswordSignInAsync(request.LoginDto.Email, request.LoginDto.Password, request.LoginDto.RememberMe, false);
    }
}
