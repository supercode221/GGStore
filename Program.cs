using BLL.Mapping;
using GGStore.MIddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Dependency Injection
DependencyConfig.RegisterDependency(builder.Services);

//Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Homepage}"
    );

app.Run();

