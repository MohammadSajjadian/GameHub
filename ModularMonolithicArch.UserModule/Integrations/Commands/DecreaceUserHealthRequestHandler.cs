using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.User.Contract.Messages.Commands;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;

namespace ModularMonolithicArch.UserModule.Integrations.Commands;

public class DecreaceUserHealthRequestHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<DecreaseUserHealthRequest, bool>
{
    public async Task<bool> Handle(DecreaseUserHealthRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.UserName))
            return false;

        var user = await userManager.FindByNameAsync(request.UserName);
        if (user is null)
            return false;

        try
        {
            user.Health--;
            await userManager.UpdateAsync(user);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
