using GameHub.Presentation.Exceptions;

namespace GameHub.Presentation.Configuration;

public static class ExceptionHandlerExtension
{
    public static IServiceCollection ConfigureExceptionsHandler(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddExceptionHandler<DefaultExceptionHandler>();

        return services;
    }

    public static WebApplication ConfigureExceptionsHandlerMiddlewares(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseExceptionHandler(x => { });

        return app;
    }
}
