using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trab_AV2.Areas.Identity.Data;
using Trab_AV2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Trab_AV2ContextConnection") ?? throw new InvalidOperationException("Connection string 'Trab_AV2ContextConnection' not found.");

builder.Services.AddDbContext<Trab_AV2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Trab_AV2User>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Trab_AV2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.MapRazorPages();
app.Run();
