using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Making session
        // Storing strings 
        //                              key         value
        HttpContext.Session.SetString("username", "pauljsyi");

        // To retrieve a string from session we use ".GetString" and pass in the key
        //      any variable                                    key
        string LocalVariable = HttpContext.Session.GetString("username");
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
