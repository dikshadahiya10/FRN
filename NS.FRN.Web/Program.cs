using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NS.FRN.Business;
using NS.FRN.Data.Entities;
using NS.FRN.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddScoped<IFurnitureBusiness,FurnitureBusiness >();
builder.Services.AddScoped<IFurnitureRepository,FurnitureRepository >();
builder.Services.AddScoped<IAccountBusiness,AccountBusiness >();
builder.Services.AddScoped<IAccountRepository,AccountRepository >();
builder.Services.AddDbContext<FRNDBContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("FRNDatabase")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.Run();
