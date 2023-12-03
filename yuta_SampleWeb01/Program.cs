using Merino;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using yuta_SampleWeb01.Controllers;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models.SeedData;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<yuta_SampleWeb01Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("yuta_SampleWeb01Context") ?? throw new InvalidOperationException("Connection string 'yuta_SampleWeb01Context' not found.")));


MerinoWebApplication.CreateWebApplication(ref builder);

//builder.Logging.ClearProviders();
//builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
//builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Authentication/Login";
        options.AccessDeniedPath = "/Authentication/AccessDenied";
    });

builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}");

app.Run();
