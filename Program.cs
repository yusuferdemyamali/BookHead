using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using BookHead.Models;
using RestSharp; // RestSharp için eklendi
using Microsoft.Extensions.Logging; // Logging için eklendi

var builder = WebApplication.CreateBuilder(args);

// Mevcut Authentication konfigürasyonu
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/admin/Login"; 
    });

builder.Services.AddAuthorization(); 

// DbContext konfigürasyonu
builder.Services.AddDbContext<denemeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

// Controllers ve Views
builder.Services.AddControllersWithViews();


// Logging konfigürasyonu
builder.Services.AddLogging(configure => 
{
    configure.AddConsole(); // Konsola log yazmak için
    configure.AddDebug(); // Debug çıktıları için
});

// RestClient için dependency injection
builder.Services.AddHttpClient(); // HttpClient desteği
builder.Services.AddScoped<IRestClient>(sp => new RestClient()); // RestSharp için

// Configuration servisini ekle
builder.Services.AddSingleton(builder.Configuration);

var app = builder.Build();

// Mevcut HTTP pipeline konfigürasyonu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication ve Authorization middleware'leri
app.UseAuthentication(); // Ekledim (önemli!)
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();