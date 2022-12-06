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
        
        return View();
    }

    // [HttpPost]
    // [Route("privacy")]
    // public IActionResult Dashboard(string name)
    // {
    //     HttpContext.Session.SetString("Name", name);

       
        

    //     return View();
    // }

    [HttpPost]
    [Route("dashboard")]
    public IActionResult Privacy(string name)
    {
        System.Console.WriteLine($"this is running, {name}");
        HttpContext.Session.SetString("Username", name);
        
        return View();
    }

    [HttpPost]
    [Route("")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
