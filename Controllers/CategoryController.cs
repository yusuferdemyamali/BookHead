using Microsoft.AspNetCore.Mvc;
using BookHead.Models;

namespace BookHead.Controllers;

public class CategoryController : Controller
{
    private readonly denemeDbContext _context;

    public CategoryController(denemeDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult Details()
    {
        var kitaplar = _context.Kitaplar.ToList();
        return View(kitaplar);
    }
    
    public IActionResult Search(string query)

    {

        // Arama terimini kullanarak veritabanında kitapları filtrele

        var results = _context.Kitaplar

            .Where(b => b.İsim.Contains(query) || b.Yazar.Contains(query)) // Kitap başlığı veya yazar adı ile eşleşenleri bul

            .ToList();


        return View("Details", results); // Sonuçları gösterecek bir view'e yönlendirin

    }
    
    public IActionResult CategoryBooks(string category)

    {

        // Kategoriye göre kitapları filtrele

        var books = _context.Kitaplar

            .Where(b => b.Kategori == category)

            .ToList();


        return View("Details",books); // Kitapları içeren view'e yönlendir

    }
}