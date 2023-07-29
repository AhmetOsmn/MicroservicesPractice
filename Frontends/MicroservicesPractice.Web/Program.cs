using FluentValidation;
using FluentValidation.AspNetCore;
using MicroservicesPractice.Shared.Services.Abstract;
using MicroservicesPractice.Shared.Services.Concrete;
using MicroservicesPractice.Web.Extensions;
using MicroservicesPractice.Web.Handler;
using MicroservicesPractice.Web.Helpers;
using MicroservicesPractice.Web.Models;
using MicroservicesPractice.Web.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddSingleton<PhotoHelper>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.AddHttpClientServices(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auth/SignIn";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    opt.Cookie.Name = "MicroservicesPracticeCookie";
});

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CourseCreateInputValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
