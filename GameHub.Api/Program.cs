using Asp.Versioning;
using GameHub.Api.Configuration;
using GameHub.Api.Endpoints.Level;
using GameHub.Application;
using GameHub.Infra;
using GameHub.Presentation.Client;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationClient();
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new HeaderApiVersionReader("api version");
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV"; // Formats the version as follow: "'v'major[.minor]"
});

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationsOptions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "Version 1.0");
        c.SwaggerEndpoint($"/swagger/v2.0/swagger.json", "Version 2.0");
    });
}

app.UseHttpsRedirection();

app.AddLevelEndpoints();

app.Run();
