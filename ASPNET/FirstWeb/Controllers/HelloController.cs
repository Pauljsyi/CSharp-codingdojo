using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers;

public class HelloController : Controller
{
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "Hello World from HelloController";
    }

    [HttpPost("Process")]
    public IActionResult Process(string FavoriteAnimal)
    {
        if (FavoriteAnimal == "dog")
        {
            ViewBag.Error = "dogs are great but pick something else";
            ViewBag.Name = "Paul";
            ViewBag.Number = 7;

        }
        Console.WriteLine(FavoriteAnimal);
        return RedirectToAction("Index");
    }
}