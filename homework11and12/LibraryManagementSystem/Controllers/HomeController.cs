using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("HomeController.Index() was called");
        return Content("<h1 style='color: red; font-size: 48px;'>HELLO WORLD!</h1><p>If you can see this, the application is working!</p>", "text/html");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
