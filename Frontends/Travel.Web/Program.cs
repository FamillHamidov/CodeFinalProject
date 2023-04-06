using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Travel.Shared.Services;
using Travel.Web.Extensions;
using Travel.Web.Handler;
using Travel.Web.Helpers;
using Travel.Web.Models;
using Travel.Web.Services;
using Travel.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PhotoHelper>();
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddHttpClientServices(builder.Configuration);
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();


builder.Services.AddHttpContextAccessor();
builder.Services.AddAccessTokenManagement();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auth/SignIn";
    opt.Cookie.Name = "travelwebcookie";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
