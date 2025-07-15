using _HACore.Logs.Implements;
using _HACore.Logs.Interfaces;
using _HACore.Logs.Models;
using GGStore.MIddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Dependency Injection
DependencyConfig.RegisterDependency(builder.Services);

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Homepage}"
    );

app.Run();

