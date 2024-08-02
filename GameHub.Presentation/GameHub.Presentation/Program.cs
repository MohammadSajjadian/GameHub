using GameHub.Application;
using GameHub.Infra;
using GameHub.Presentation.Client;
using GameHub.Presentation.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureBlazor();

builder.Services.AddPresentationClient();
builder.Services.AddApplication();
builder.Services.AddInfraStructure(builder.Configuration);

builder.Services.ConfigureIdentity();
builder.Services.ConfigureSignalR();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureHostedServices();

var app = builder.Build();

await app.ConfigureRole();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger().UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "Version 1.0");
        c.SwaggerEndpoint($"/swagger/v2.0/swagger.json", "Version 2.0");
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseResponseCompression();
app.ConfigureExceptionsHandlerMiddlewares();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images")),
    RequestPath = "/Images"
});
app.ConfigureIdentityMiddlewares();
app.UseAntiforgery();
app.ConfigureEndpoints();
app.ConfigureBlazorMiddleWares();
app.ConfigureSignalRMiddleWares();

app.Run();
