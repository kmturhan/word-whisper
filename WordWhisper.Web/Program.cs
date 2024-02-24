using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WordWhisper.Core;
using WordWhisper.DataAccess;
using WordWhisper.Web.Models;
using AutoMapper;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.Repository.Abstract;
using WordWhisper.Repository.Concrete;
using WordWhisper.Infrastructer;
using Microsoft.AspNetCore.Authentication.Cookies;
using WordWhisper.Entities.Concrete;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
AppSetting.ConnectionString = builder.Configuration["ConnectionStrings:SqlServer"];
AppSetting.JwtIssuer = builder.Configuration["JwtConfig:Issuer"];
AppSetting.JwtAudience = builder.Configuration["JwtConfig:Audience"];
AppSetting.JwtSigninKey = builder.Configuration["JwtConfig:SigninKey"];
builder.Services.AddDbContext<WordWhisperEFContext>(x => x.UseLazyLoadingProxies().UseSqlServer(AppSetting.ConnectionString));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

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
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});
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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<WordWhisperEFContext>();

        // Role tablosunda kayýt var mý kontrol et
        if (!dbContext.Roles.Any())
        {
            // Kayýt yoksa varsayýlan kayýtlarý ekle
            dbContext.Roles.AddRange(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "User" }
            );

            // Deðiþiklikleri kaydet
            dbContext.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        // Hata durumunda hata günlüðüne kaydet
        Console.WriteLine("Hata meydana geldi: " + ex.Message);
    }
}

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
