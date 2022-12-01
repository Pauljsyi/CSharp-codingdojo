using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;
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
        
        @ViewBag.name = name;
        @ViewBag.location = location;
        @ViewBag.language = language;
        if (comments == null) {
            @ViewBag.comments = nocomment;
        } else {
        @ViewBag.comments = comments;
        }

        // Console.WriteLine($"{comments.Length}");
        
        
        return View();
    }


}