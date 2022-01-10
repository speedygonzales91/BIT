using BIT_Client;
using BIT_Client.Service;
using BIT_Client.Service.IService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
