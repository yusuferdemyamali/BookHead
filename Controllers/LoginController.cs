using Microsoft.AspNetCore.Mvc;

namespace BookHead.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }
    
}