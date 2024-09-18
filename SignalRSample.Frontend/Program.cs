using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SignalRSample.Frontend;
using SignalRSample.Frontend.HubServise;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("MyApi", client => { client.BaseAddress = new Uri("https://localhost:7201/api/"); });
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ChatHubServices>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

await builder.Build().RunAsync();