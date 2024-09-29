using Microsoft.Extensions.FileProviders;
using ModularMonolithicArch.ImageGame.Api;
using ModularMonolithicArch.User.Infrastructure;
using ModularMonolithicArch.Web.Client;
using ModularMonolithicArch.Web.Configuration;
using ModularMonolithicArch.WordGame.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureBlazor();

builder.Services.ConfigureSharedWebClient(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSignalR();
builder.Services.ConfigureSwagger();

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

app.ConfigureImageGameModuleEndpoints();
app.ConfigureUserModuleEndpoints();
app.ConfigureWordGameModuleEndpoints();
app.ConfigureSignalRMiddleware();

app.ConfigureBlazorMiddleWares();

app.Run();
