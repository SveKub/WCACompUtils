using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WCACompUtils;
using WCACompUtils.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://live.worldcubeassociation.org/api") });
builder.Services.AddScoped<ICompetitiorsService, CompetitorsService>();

await builder.Build().RunAsync();
