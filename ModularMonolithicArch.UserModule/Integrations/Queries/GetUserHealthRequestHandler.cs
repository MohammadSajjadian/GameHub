using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.User.Contract;
using ModularMonolithicArch.User.Contract.Messages.Queries;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;

namespace ModularMonolithicArch.UserModule.Integrations.Queries;

public class GetUserHealthRequestHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<GetUserHealthRequest, ApplicationUserDto?>
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public async Task<ApplicationUserDto?> Handle(GetUserHealthRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName);
        if (user is null)
        {
            return null;
        }

        return new() { Health = user.Health };
    }
}
