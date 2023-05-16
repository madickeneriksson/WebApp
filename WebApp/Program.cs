using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helpers.Repositories;
using WebApp.Helpers.Services;
using WebApp.Models.Identity;
using WebApp.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));


//Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();

//Repo
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();

builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();


//Hantera lösenord/mejl vid inloggning
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();
    // Claim för displayname


// Hantera cookies
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath= "/denied";
});


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
