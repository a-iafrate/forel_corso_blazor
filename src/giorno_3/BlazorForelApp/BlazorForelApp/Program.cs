using BlazorForelApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Aggiunge Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Aggiunge Blazor.Bootstrap
builder.Services.AddBlazorBootstrap();

builder.Services.AddLocalization();

await builder.Build().RunAsync();
