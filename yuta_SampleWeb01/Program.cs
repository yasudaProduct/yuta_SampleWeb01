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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
