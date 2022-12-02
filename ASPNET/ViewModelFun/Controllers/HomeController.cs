using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

     // all our other controller code
[HttpGet("")]
public IActionResult Index()
{
    string messageTitle = "Here is a message";
    string message = "Nulla quis lorem ut libero malesuada feugiat. Nulla quis lorem ut libero malesuada feugiat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Pellentesque in ipsum id orci porta dapibus. Sed porttitor lectus nibh. Proin eget tortor risus. Pellentesque in ipsum id orci porta dapibus. Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem.";

    Dictionary<string, string> messages = new Dictionary<string, string>();
    messages.Add("messageTitle", messageTitle);
    messages.Add("message", message);
    return View(messages);
}

[HttpGet("user")]
public IActionResult User()
{
    User newUser = new User()
    {
        FirstName = "Paul",
        LastName = "Yi"
    };
    return View(newUser);
}

[HttpGet("users")]
public IActionResult Users()
{
    User paulyi = new User(){FirstName = "Paul", LastName = "Yi"};
    User georgeyi = new User() {FirstName = "George", LastName="Yi"};
    User jamieyi = new User() {FirstName = "Jamie", LastName="Yi"};
    User happyyi = new User() {FirstName = "happy", LastName="Yi"};

    List<User> users = new List<User>() {paulyi, georgeyi, jamieyi, happyyi};
    return View(users);
}

[HttpGet("numbers")]
public IActionResult Numbers()
{
    List<int> numbers = new List<int>() {1,2,10,21,8,7,3};
    return View(numbers);

}

}
