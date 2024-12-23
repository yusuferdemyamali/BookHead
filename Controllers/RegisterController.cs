using Microsoft.AspNetCore.Mvc;

namespace BookHead.Controllers;

public class RegisterController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}