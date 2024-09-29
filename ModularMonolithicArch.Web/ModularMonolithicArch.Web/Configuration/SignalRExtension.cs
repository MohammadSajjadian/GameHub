using Microsoft.AspNetCore.ResponseCompression;
using ModularMonolithicArch.ImageGame.Infrastructure.Hubs;

namespace ModularMonolithicArch.Web.Configuration;

public static class SignalRExtension
{
    public static IServiceCollection ConfigureSignalR(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSignalR();
        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"]);
        });

        return services;
    }

    public static IEndpointRouteBuilder ConfigureSignalRMiddleware(this IEndpointRouteBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapHub<RoomHub>("/room-hub");
        app.MapHub<ImageGameHub>("/imageGame-hub");

        return app;
    }
}
