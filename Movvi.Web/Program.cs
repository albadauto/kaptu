using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Movvi.Web.Components;
using Movvi.Web.Extensions;
using Movvi.Web.Helpers;
using Movvi.Web.Repository;
using Movvi.Web.Repository.Interface;
using Movvi.Web.Services;
using Movvi.Web.Services.Interface;
using MudBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClientCustom();
builder.Services.AddScoped<CustomAuthenticationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(c => c.GetRequiredService<CustomAuthenticationProvider>());
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost")
});
var keysDirectory = "/keys";

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysDirectory))
    .SetApplicationName("movvi-app");
var app = builder.Build();
var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
AppSettingsHelper.Initialize(builder.Configuration, builder.Environment, httpContextAccessor);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
