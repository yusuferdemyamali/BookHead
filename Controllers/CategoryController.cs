using Microsoft.AspNetCore.Mvc;

namespace BookHead.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult Details()
    {
        return View();
    }
}