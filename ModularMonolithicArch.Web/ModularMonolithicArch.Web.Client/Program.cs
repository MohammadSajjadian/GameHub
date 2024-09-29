using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ModularMonolithicArch.Web.Client;
using ModularMonolithicArch.Web.Client.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.ConfigureSharedWebClient(builder.Configuration);
builder.Services.ConfigureIdentity();

await builder.Build().RunAsync();
