using GameHub.Application;
using GameHub.Domain.Entities;
using GameHub.Infra;
using GameHub.Infra.BackroundTasks;
using GameHub.Presentation.Client;
using GameHub.Presentation.Components;
using GameHub.Presentation.Components.Pages.Account;
using GameHub.Presentation.Configuration;
using GameHub.Presentation.Endpoints.Account;
using GameHub.Presentation.Endpoints.Category;
using GameHub.Presentation.Endpoints.User;
using GameHub.Presentation.Endpoints.WordGame.Level;
using GameHub.Presentation.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddPresentationClient();
builder.Services.AddApplication();
builder.Services.AddInfraStructure(builder.Configuration);

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddIdentity();
builder.Services.AddSwaggerOptions();
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();

builder.Services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationsOptions>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddHostedService<HealthBackgroundService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    await IdentityConfigurationsExtension.InitializeRole(roleManager, userManager);
}

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

app.UseExceptionHandler(x => { });
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapLevelEndpoints();
app.MapCategoryEndpoints();
app.MapUserEndpoints();
app.MapLogOutEndpoint();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GameHub.Presentation.Client._Imports).Assembly);

app.Run();
