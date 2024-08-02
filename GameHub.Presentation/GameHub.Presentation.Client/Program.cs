using GameHub.Presentation.Client;
using GameHub.Presentation.Client.Configuration;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddPresentationClient();
builder.Services.ConfigureIdentity();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GameHub.Application.ServiceCollectionExtension).Assembly));

await builder.Build().RunAsync();
