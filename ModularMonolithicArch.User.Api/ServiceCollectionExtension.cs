using Microsoft.AspNetCore.Routing;
using ModularMonolithicArch.User.Api.Endpoints.Account;

namespace ModularMonolithicArch.User.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IEndpointRouteBuilder ConfigureUserModuleEndpoints(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapLogOutEndpoint();

        return app;
    }
}
