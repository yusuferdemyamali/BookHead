using System.Security.Claims;
using BookHead.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookHead.Controllers;

[Authorize]
public class AdminController : Controller
{
    
    private readonly denemeDbContext _context;

    public AdminController(denemeDbContext context)
    {
        _context = context;
    }
    
    public ActionResult Kitaplar()
    {
        var kitaplar = _context.Kitaplar.ToList();
        return View(kitaplar);
    }

    public IActionResult KitapSil(int id)
    {
        var kitap = _context.Kitaplar.Find(id);
        return View(kitap);
    }

    [HttpPost]
    public IActionResult KitapSil(Kitap kitap)
    {
        _context.Kitaplar.Remove(kitap);
        _context.SaveChanges();
        return RedirectToAction("Kitaplar");
    }
    
    public IActionResult KitapDuzenle(int KitapID)
    {
        var kitap = _context.Kitaplar.Find(KitapID);
        
        return View(kitap); // Kitap modelini view'a gönder
    }

    [HttpPost]
    public IActionResult KitapDuzenle(Kitap model)
    {
        if (ModelState.IsValid)
        {
            _context.Update(model); // Modeli güncelle
            _context.SaveChanges(); // Değişiklikleri kaydet
            return RedirectToAction("Kitaplar"); // Kitaplar sayfasına yönlendir
        }
        return View(model); // Hata varsa aynı view'ı tekrar göster
    }
    
    
    public ActionResult KitapEkle()
    {
        return View();
    }

    [HttpPost]
    public ActionResult KitapEkle(Kitap kitap)
    {

            // Seçilen kategori_id doğrudan veritabanına kaydedilecek
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("Kitaplar");
        
    

    }
    
    // GET
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    
    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string username, string password)
    {

        if (username == "admin" && password == "123") 
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin") 
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false, 
            };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Admin"); 
        }

        ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı!";
        return View();
    }
    
}