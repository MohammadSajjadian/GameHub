using GameHub.Presentation.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

namespace GameHub.Presentation.Configuration;

public static class SignalRExtension
{
    public static IServiceCollection ConfigureSignalR(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSignalR();
        services.AddResponseCompression(opts => { opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/octet-stream"]); });

        return services;
    }

    public static IEndpointRouteBuilder ConfigureSignalRMiddleWares(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapHub<RoomHub>("/room-hub");
        app.MapHub<ImageGameHub>("/imageGame-hub");

        return app;
    }
}
