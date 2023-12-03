using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models.SeedData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<yuta_SampleWeb01Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("yuta_SampleWeb01Context") ?? throw new InvalidOperationException("Connection string 'yuta_SampleWeb01Context' not found.")));

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
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
