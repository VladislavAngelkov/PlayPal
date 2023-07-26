using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Repositories;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Data;
using PlayPal.Data.Models;
using PlayPal.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PlayPalDbContext>(options =>
{
    options
    //.UseLazyLoadingProxies()
    .UseSqlServer(connectionString);
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<PlayPalUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireConfirmedAccount");

    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireDigit");

    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireNonAlphanumeric");

    options.Password.RequiredLength = builder.Configuration.GetValue<int>("AccountConfiguration:RequiredLength");

    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireUppercase");

    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("AccountConfiguration:RequireLowercase");
})
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<PlayPalDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Home/Index";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.AddServices();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAuthorization(policy =>
{
    policy.AddPolicy(PlayPalPolicyNames.Adminstration, options =>
    {
        options.RequireRole(PlayPalRoleNames.Administrator);
        options.RequireClaim(PlayPalClaimTypes.AdministratorId);
    });

    policy.AddPolicy(PlayPalPolicyNames.FieldManagment, options =>
    {
        options.RequireRole(PlayPalRoleNames.FieldOwner);
        options.RequireClaim(PlayPalClaimTypes.FieldOwnerId);
    });

    policy.AddPolicy(PlayPalPolicyNames.Player, options =>
    {
        options.RequireRole(PlayPalRoleNames.Player);
        options.RequireClaim(PlayPalClaimTypes.PlayerId);
    });
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
