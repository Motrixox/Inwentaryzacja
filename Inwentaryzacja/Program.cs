using Inwentaryzacja;
using Inwentaryzacja.Interfaces;
using Inwentaryzacja.MapperProfiles;
using Inwentaryzacja.Models;
using Inwentaryzacja.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//Starting the app
var builder = WebApplication.CreateBuilder(args);

//The app config
var config = builder.Configuration;

//Setting the database, you can switch between "UseInMemoryDatabase("nameOfTheDatabase")" and "UseNpgsql("connectionString")"
builder.Services.AddDbContext<InventoryDbContext>(options =>
            //options.UseNpgsql("Server=localhost;Port=5432;Database=inventory;User Id=postgres;Password=postgres;"));
             options.UseInMemoryDatabase("test"));

//Adding Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<InventoryDbContext>();

//Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
   {
       options.LoginPath = "/api/Login";
       options.Cookie.SameSite = SameSiteMode.None;
   });

builder.Services.ConfigureExternalCookie(options => { options.Cookie.SameSite = SameSiteMode.None; });

//Adding the repository service
builder.Services.AddScoped<IRepositoryService<Employee>, RepositoryService<Employee>>();
builder.Services.AddScoped<IRepositoryService<Device>, RepositoryService<Device>>();
builder.Services.AddScoped<IRepositoryService<DeviceType>, RepositoryService<DeviceType>>();
builder.Services.AddScoped<IRepositoryService<IssuedDevice>, RepositoryService<IssuedDevice>>();

//Adding Automapper profiles
builder.Services.AddAutoMapper(typeof(DeviceTypeProfile), typeof(EmployeeProfile), typeof(IssuedDeviceProfile), typeof(DeviceProfile));

//Adding controllers
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();