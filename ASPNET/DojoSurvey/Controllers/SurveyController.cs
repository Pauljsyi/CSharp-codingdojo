using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;
using DojoSurvey.Models;
public class SurveyController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        // will attempt to serve
            // Views/Hello/Index.cshtml
        // or if that file isn't there:
            // Views/Shared/Index.cshtml
        return View();
    }
    [HttpPost]
    [Route("result")]
    public IActionResult FormSubmission(string name, string location, string language, string comments)
    {
        Console.WriteLine($"Name: {name} \nLocation: {location} \nLanguage: {language} \nComments: {comments}  ");

        // how to add input data into a list to iterate through
        // List<string> surveydata = new List<string>() {name, location, language, comments};

        // ICollection<string> surveyCollection = surveydata;
        string nocomment = "No Comment";
        // ViewBag to send data to front
        // @ViewBag.name = name;
        // @ViewBag.location = location;
        // @ViewBag.language = language;
        // if (comments == null) {
        //     @ViewBag.comments = nocomment;
        // } else {
        // @ViewBag.comments = comments;
        // }
        Survey inputData = new Survey(){
            name = name,
            location = location,
            language = language,
            comments = comments
        };

        // model validations...
        if (ModelState.IsValid)
        {
            Console.WriteLine($"this is running");

            return View(inputData);
            // return RedirectToAction("Index");
        } 
        else
        {
            Console.WriteLine($"error is running");
            
            
            return View("Index");
        }

        // Instantiate a new class using Survey Model
        


        // Console.WriteLine($"{comments.Length}");
        
        
        // return View(inputData);
    }


}