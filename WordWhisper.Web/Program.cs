using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WordWhisper.Core;
using WordWhisper.Core.Services;
using WordWhisper.DataAccess;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Services;
using WordWhisper.Web.Models;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
AppSetting.ConnectionString = builder.Configuration["ConnectionStrings:SqlServer"];
AppSetting.JwtIssuer = builder.Configuration["JwtConfig:Issuer"];
AppSetting.JwtAudience = builder.Configuration["JwtConfig:Audience"];
AppSetting.JwtSigninKey = builder.Configuration["JwtConfig:SigninKey"];
builder.Services.AddDbContext<WordWhisperContext>(x => x.UseSqlServer(AppSetting.ConnectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = AppSetting.JwtIssuer,
        ValidAudience = AppSetting.JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.JwtSigninKey))
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program));
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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "User",
        areaName: "User",
        pattern: "User/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});



app.Run();
