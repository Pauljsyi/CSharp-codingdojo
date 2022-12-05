using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("Username", "Paul Yi");
        return View();
    }

    // [HttpPost]
    // [Route("privacy")]
    // public IActionResult Dashboard(string name)
    // {
    //     HttpContext.Session.SetString("Name", name);

       
        

    //     return View();
    // }


    public IActionResult Privacy()
    {
        string? LocalVariable = HttpContext.Session.GetString("Username");
        Console.WriteLine(LocalVariable);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
