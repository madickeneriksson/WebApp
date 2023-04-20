using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
// Registerar som en service scooped, behöver inte göra insatser.

builder.Services.AddScoped<UserService>();
// Registera service

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
