using BlazorForelApp;
using BlazorForelApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Aggiunge Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Aggiunge Blazored.SessionStorage
builder.Services.AddBlazoredSessionStorage();

// Aggiunge il servizio per i cookie
builder.Services.AddScoped<ICookieService, CookieService>();

await builder.Build().RunAsync();
