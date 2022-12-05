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
    public IActionResult FormSubmission(Survey survey)
    {
        // Console.WriteLine($"Name: {name} \nLocation: {location} \nLanguage: {language} \nComments: {comments}  ");

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
        // System.Console.WriteLine($"{survey.name}");
        

        // model validations...
        if (ModelState.IsValid)
        {

        //     Survey inputData = new Survey(){
        //     name = name,
        //     location = location,
        //     language = language,
        //     comments = comments
        // };
            Console.WriteLine($"this is running");
            // return View(inputData);
            return View(survey);
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