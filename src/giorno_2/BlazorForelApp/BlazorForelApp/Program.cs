using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorForelApp;
using BlazorForelApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddCascadingValue(sp => new AppConfiguration { Theme = "Custom123" });

// Aggiunge Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Aggiunge Blazored.SessionStorage
builder.Services.AddBlazoredSessionStorage();

// Aggiunge il servizio per i cookie
builder.Services.AddScoped<ICookieService, CookieService>();

await builder.Build().RunAsync();
