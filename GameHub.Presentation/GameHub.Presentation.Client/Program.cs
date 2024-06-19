using Blazored.LocalStorage;
using GameHub.Presentation.Client;
using GameHub.Presentation.Client.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddPresentationClient();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GameHub.Application.ServiceCollectionExtension).Assembly));

await builder.Build().RunAsync();
