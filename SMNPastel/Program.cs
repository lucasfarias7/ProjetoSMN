using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Net.Http.Headers;
using SMNPastel.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.GetSettingsDb();
var sendGridApi = builder.ConfigureSendGrid();

builder.Services.RegisterServices(sendGridApi);
builder.Services.RegisterRepositorys();
builder.Services.ConfigureMapper();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.AccessDeniedPath = "/Home/AcessoNegado/";
        o.LoginPath = "/Login/";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (httpcontext, next) =>
{
    httpcontext.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate, max-age=0";
    httpcontext.Response.Headers[HeaderNames.Expires] = "-1";
    await next();
});

app.MapGet("/", async context =>
{  
    if (!context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/login/home/login");
    }
    else
    {
        context.Response.Redirect("/home");
    }
});

app.MapAreaControllerRoute(
    name: "Login",
    areaName: "Login",
    pattern: "login/{controller=Home}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
