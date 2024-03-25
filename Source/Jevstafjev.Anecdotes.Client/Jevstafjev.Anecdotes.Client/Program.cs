using Jevstafjev.Anecdotes.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AnecdotesApi",
    client => client.BaseAddress = new Uri("https://localhost:10001"));

builder.Services.AddHttpClient("AnecdotesApi.AuthenticationClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:10001");
}).AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
    .ConfigureHandler(
        authorizedUrls: new[] { "https://localhost:10001" }));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
    options.UserOptions.RoleClaim = "role";
});

await builder.Build().RunAsync();
