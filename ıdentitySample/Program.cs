using �dentitySample.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestLayer.Managers;
using TestLayer.Services;
using TestLayer.Extentions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("HasanDb"));
});

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 5;
    x.Lockout.MaxFailedAccessAttempts = 5;
    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); 



    


}).AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddTestLayetDependency();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
