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
    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(item => item.DishId == dishId);
        return View("EditDishForm", DishToEdit);
    }
    // UPDATE DISH ACTION
    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish UpdatedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(a => a.DishId == dishId);
        if (DishToUpdate == null)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            DishToUpdate.ChefName = UpdatedDish.ChefName;
            DishToUpdate.DishName = UpdatedDish.DishName;
            DishToUpdate.NumOfCalories = UpdatedDish.NumOfCalories;
            DishToUpdate.Rating = UpdatedDish.Rating;
            DishToUpdate.Description = UpdatedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ShowOneDish", DishToUpdate);
        } else {
        return View("EditDishForm", DishToUpdate);
        }
    }
    // DELETE DISH ACTION
    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DestroyDish(int dishId)
    {
        Dish? DishToDestroy = _context.Dishes.SingleOrDefault(a => a.DishId == dishId);
        if (DishToDestroy == null)
        {
            return RedirectToAction("Index");
        }
        _context.Dishes.Remove(DishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
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
