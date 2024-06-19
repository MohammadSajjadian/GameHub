using Asp.Versioning;

namespace GameHub.Presentation.Configuration;

public static class SwaggerConfigurationsExtension
{
    public static IServiceCollection AddSwaggerOptions(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddEndpointsApiExplorer();
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new HeaderApiVersionReader("apiversion");
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VV"; // Formats the version as follow: "'v'major[.minor]"
        });
        services.AddSwaggerGen();

        return services;
    }
}
