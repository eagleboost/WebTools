using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebTools;
using WebTools.Services;
using WebTools.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<IPeriodicExecutor, PeriodicExecutor>();
builder.Services.AddSingleton<IAppStorageService, AppStorageService>();
builder.Services.AddSingleton<AppLocalStorageService>();
builder.Services.AddSingleton<AppWebDavStorageService>();

await builder.Build().RunAsync();
