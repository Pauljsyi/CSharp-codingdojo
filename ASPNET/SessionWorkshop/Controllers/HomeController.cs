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
        string name = HttpContext.Session.GetString("Username");
        System.Console.WriteLine($"index is running, {name}");
        HttpContext.Session.Clear();
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
    public IActionResult Dashboard(string name)
    {
        System.Console.WriteLine($"this is running, {name}");
        HttpContext.Session.SetString("Username", name);
        HttpContext.Session.SetInt32("num", 22);
        
        
        return View();
    }

    [HttpPost]
    
    public IActionResult AddByOne(int number = 1)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before adding 1, {currentNum} ");
        currentNum += number;
        HttpContext.Session.SetInt32("num", currentNum.Value);
        System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return View("dashboard");
    }

    [HttpPost]
    
    public IActionResult SubtractByOne(int number = 1)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before subtracting 1, {currentNum} ");
        currentNum -= number;
        HttpContext.Session.SetInt32("num", currentNum.Value);
        System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return View("dashboard");
    }
    [HttpPost]
    
    public IActionResult MultiplyByTwo(int number = 2)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before subtracting 1, {currentNum} ");
        currentNum *= number;
        HttpContext.Session.SetInt32("num", currentNum.Value);
        System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return View("dashboard");
    }

    [HttpPost]
    
    public IActionResult AddRandom()
    {
        Random rnd = new Random();

        int randomNum = rnd.Next(1, 100);
        
        int? currentNum = HttpContext.Session.GetInt32("num");
        
        currentNum += randomNum;
        System.Console.WriteLine($" adding by random number -> {randomNum}, equaling -> {currentNum} ");
        HttpContext.Session.SetInt32("num", currentNum.Value);
        // System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return View("dashboard");
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
