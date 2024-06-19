namespace GameHub.Presentation.Endpoints.Account;

public static class AccountGroup
{
    public static IEndpointRouteBuilder MapLogOutEndpoint(this IEndpointRouteBuilder endpoint)
    {
        ArgumentNullException.ThrowIfNull(endpoint);

        var group = endpoint.MapGroup("/")
            .WithTags("GameHub.Presentation");

        group.MapPost("/logout", AccountEndpoints.LogOutAsync)
            .RequireAuthorization();

        return endpoint;
    }
}
