using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModularMonolithicArch.User.Contract;
using ModularMonolithicArch.User.Contract.Messages.Queries;
using ModularMonolithicArch.UserModule.Shared.Domain.Entity;

namespace ModularMonolithicArch.UserModule.Integrations.Queries;

public class GetCurrentUserRequestHandler(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetCurrentUserRequest, ApplicationUserDto>
{
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    public async Task<ApplicationUserDto> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(httpContextAccessor.HttpContext.User.Identity?.Name!);
        return new() { Id = user!.Id, UserName = user.UserName!};
    }
}
