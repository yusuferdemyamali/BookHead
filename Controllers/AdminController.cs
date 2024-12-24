using Microsoft.AspNetCore.Mvc;

namespace BookHead.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Login()
    {
        return View();
    }
}