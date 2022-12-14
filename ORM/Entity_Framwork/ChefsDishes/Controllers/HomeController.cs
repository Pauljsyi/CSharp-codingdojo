using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    // NEW CHEF FORM
    [HttpGet("chef/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }


    // CREATE CHEF ACTION
    [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        // System.Console.WriteLine($"new chef!! -> {newChef.Birthdate}");
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NewChef");
    }

    // GET ALL CHEFS
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        MyViewModel MyModel = new MyViewModel
        {
            AllChefs = _context.Chefs.Include(a => a.CreatedDishes).ToList()
        };
        return View("Index", AllChefs);
    }

    // create dish form
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    { 
        MyViewModel MyModel = new MyViewModel
        {
            AllChefs = _context.Chefs.ToList()
        };
        // ViewBag.AllChefs = _context.Chefs.ToList();
        return View("NewDishForm", MyModel);
    }



    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        
        System.Console.WriteLine($"NEW DISH!!!!!!! ---->\n ChefId: {newDish.ChefId}\n DishId: {newDish.DishId}\n Dish Name: {newDish.DishName}\n # of Calories: {newDish.NumOfCalories}\n Tastiness: {newDish.Tastiness}");

        // Doesn't Validate!
        // NullReferenceException: Object reference not set to an instance of an object.
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("NewDishForm");
        }
        

    }

    [HttpGet("dishes")]
    public IActionResult GetAllDishes()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("ViewAllDish", AllDishes);
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
