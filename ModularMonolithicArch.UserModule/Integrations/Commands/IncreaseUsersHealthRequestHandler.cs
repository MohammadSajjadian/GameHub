using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModularMonolithicArch.User.Contract.Messages.Commands;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;
using ModularMonolithicArch.UserModule.Shared.Persistence;

namespace ModularMonolithicArch.UserModule.Integrations.Commands;

public class IncreaseUsersHealthRequestHandler(UserContext db, UserManager<ApplicationUser> userManager) : IRequestHandler<IncreaseUsersHealthRequest, int>
{
    private readonly UserContext db = db;
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public async Task<int> Handle(IncreaseUsersHealthRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await userManager.Users
                .Where(u => u.Health < 3)
                .ForEachAsync(u => u.Health++, cancellationToken);

            await db.SaveChangesAsync(cancellationToken);

            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return -1;
        }
    }
}
