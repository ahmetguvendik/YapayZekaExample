using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class AIController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}