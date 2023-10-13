using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmSample;
using System.Net;
using BlazorWasmSample.Services;
using Google.Api;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<FunkoAPI>();
builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddSingleton<IGlobalVariables, GlobalVariables>();
await builder.Build().RunAsync();
public interface IGlobalVariables
{
    string MyGlobalVariable { get; set; }
    string MyColorVariable { get; set; }
}

public class GlobalVariables : IGlobalVariables
{
    public string MyGlobalVariable { get; set; } = "Logged Out";
    public string MyColorVariable { get; set; } = "rgba(185, 208, 240, 1)";
}