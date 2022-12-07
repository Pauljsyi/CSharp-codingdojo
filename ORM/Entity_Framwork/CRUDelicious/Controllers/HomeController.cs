using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // SHOW ALL DISH VIEW
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDish = _context.Dishes.ToList();
        return View("Index", AllDish);
    }

    // SHOW ONE DISH VIEW
    [HttpGet("dishes/{dishId}")]
    public IActionResult ShowOneDish(int dishId)
    {
        List<Dish> AllDish = _context.Dishes.ToList();
        System.Console.WriteLine(dishId);
        Dish? SingleDish = AllDish.FirstOrDefault(d => d.DishId == dishId);

        ViewBag.OneDish = SingleDish;

        return View("ShowDish", SingleDish);
    }

    // NEW DISH FORM VIEW

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("NewDishForm");
    }

    // CREATE NEW DISH ACTION
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NewDishForm");
    }

    // EDIT DISH FORM VIEW
    // UPDATE DISH ACTION
    // DELETE DISH ACTION

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
