using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Data;
using PlayPal.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PlayPalDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<PlayPalUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireConfirmedAccount");

    options.Password.RequireDigit = true;

    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireNonAlphanumeric");

    options.Password.RequiredLength = builder.Configuration.GetValue<int>("AccountConfiguration:RequiredLength");

    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireUppercase");

    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireLowercase");

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PlayPalDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
