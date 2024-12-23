using Microsoft.AspNetCore.Mvc;

namespace BookHead.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}