using Microsoft.EntityFrameworkCore;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
AppSetting.ConnectionString = builder.Configuration["ConnectionStrings:SqlServer"];
builder.Services.AddDbContext<WordWhisperContext>(x => x.UseSqlServer(AppSetting.ConnectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Logger.LogInformation("START PROJECT");


//builder.Services.AddDbContext<WordWhisperApplicationContext>(options => options.UseSqlServer(connectionStringSql));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
