using Asp.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GameHub.Presentation.Configuration;

public static class SwaggerExtension
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
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

        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, SwaggerOptions>();

        return services;
    }
}
