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
    [Route("login")]
    public IActionResult Login(string name)
    {

        if (name == null) 
        {
            // System.Console.WriteLine("this is running");
           return RedirectToAction("Index");
        }

        System.Console.WriteLine($"this is running, {name}");
        HttpContext.Session.SetString("Username", name);
        HttpContext.Session.SetInt32("num", 22);
        return RedirectToAction("Dashboard");
    }

    [HttpGet]
    [Route("dashboard")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("Username") == null)
        {
            return RedirectToAction("Index");
        }
        
        
        return View();
    }

    [HttpPost]
    [Route("addone")]
    public IActionResult AddByOne(int number = 1)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before adding 1, {currentNum} ");
        currentNum += number;
        HttpContext.Session.SetInt32("num", (int)currentNum);
        System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    [Route("subtractone")]
    public IActionResult SubtractByOne(int number = 1)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before subtracting 1, {currentNum} ");
        currentNum -= number;
        HttpContext.Session.SetInt32("num",(int)currentNum);
        System.Console.WriteLine($"subtract by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return RedirectToAction("Dashboard");
    }
    [HttpPost]
    [Route("multiply")]
    public IActionResult MultiplyByTwo(int number = 2)
    {
        int? currentNum = HttpContext.Session.GetInt32("num");
        System.Console.WriteLine($"this is current num before multiplying by 2, {currentNum} ");
        currentNum *= number;
        HttpContext.Session.SetInt32("num", (int)currentNum);
        System.Console.WriteLine($"multiply by 2 is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    [Route("addrandom")]
    public IActionResult AddRandom()
    {
        Random rnd = new Random();

        int randomNum = rnd.Next(1, 10);
        
        int? currentNum = HttpContext.Session.GetInt32("num");
        
        currentNum += randomNum;
        System.Console.WriteLine($" adding by random number -> {randomNum}, equaling -> {currentNum} ");
        HttpContext.Session.SetInt32("num",(int)currentNum);
        // System.Console.WriteLine($"add by one is running, {currentNum} ");
        // HttpContext.Session.SetInt32("num", currentNum);
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
