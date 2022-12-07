# ASP.NET Core
## Starting an ASP.NET Core Project
```
dotnet new web --no-https -o ProjectName
```
- by default, ASP will want to run applications with HTTPS, which is secure but will require HTTPS certs for our local browser, so we'll be turning it off during the course
- the Program.cs file will have some new code:
```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```
- the launchSettings.json file contains many setting including the applicationUrl, which will be on a randomly selected port between 5000 and 5300
- when you *dotnet run* your project, it will also tell you which port it is running on
### Opening a live feed in the terminal
```
dotnet watch run
```
- dotnet watch run will open the project for you and react to any changes you make and update in real time
### Development Mode
- we need to set our environment to Development Mode so that we can see the 
**Developer Exception Page**, which will help with debugging.
```cs
// Windows
setx ASPNETCORE_ENVIRONMENT Development

// Mac/Linux
export ASPNETCORE_ENVIRONMENT=Development
```
- after running one of the previous lines, restart your terminal and VSCode
- When we're ready to deploy our project, the system will need to be set back to Production Mode so that users can't see the error messages
---
## Setting up MVC
### Adding MVC
-at the top of the Program.cs file:
```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
```
- Builder is an instance of the WebApplication class that allows us to streamline getting our application up and running quickly

### Adding to our MVC Service
- we need to tell our builder to bring in a **Service**, an object that we can bring in using **Dependency Injection**
- services bring various handy features to our project
- to add our MVC service, update the Program.cs file with the service BEFORE calling the build method
```cs
var builder = WebApplication.CreateBuilder(args);
// Add service here
builder.Services.AddControllerWithViews();
var app = builder.Build();
```
### Adding Methods
- also add the following to Program.cs:
```cs
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
```
### Mapping to our Controller
- the final change is to the MapGet() method.  Replace it with the following code:
```cs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
### Putting it all Together
- the final product should look like this:
```cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
```
---
## Controllers
### Folder Structure
- create a Controllers folder (must be named exactly Controllers) in the project directory
- create a different controller file for each major kind of model in the project. i.e. UserController, ProductController
### Making a Controller 
- basic structure:
```cs
// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace YourNamespace.Controllers;
public class UserController : Controller
{      
    [HttpGet] 
    [Route("")]
    public string Index()
    {
        return "Hello World from HelloController!";
    }
}
```
- **namespace** ties all the files of your project together, like the cover of a book, and the files inside are the pages.
- the .Controllers in the namespace flags the file as a controller file
---
## Routing
- Routes are added to the controllers file and allows the user to move from page to page
- creating routes using ASP requires two things:  what type of route and what the route is called.
### Route Type
```cs
[HttpGet]
[Route("")]
// OR
[HttpGet("")]
```
- use GET routes to render a page and POST routes to handle form submissions and other processes hidden from the user
### Route Name
- the route goes inside the " " and will be the address following the http://localhost:5XXX/
```cs
[Route("about")]
// Would direct the user to http://localhost:5XXX/about
```
### Route Parameters
- the routes can contain parameters that we can use inside the methods
- the argument type can be string or int, depending on the url expected
```cs
public class HelloController : Controller
{
    [HttpGet("greet/{name}")]
    public string Greet(string name)
    {
        return $"Hello {name}!";
    }
    
    [HttpGet("greet/{name}/{time}")]
    public string GreetTime(string name, string time)
    {
    	return $"Good {time}, {name}!";
    }
}
```
---
## Rendering Views
- the return type of our method in the controllers needs to be changed to **ViewResult**
- the method must then return a View();
- inside the View(), include the name of your .cshtml view file
```cs
using Microsoft.AspNetCore.Mvc;
namespace RenderingViews.Controllers; // your project namespace here

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index"); // .cshtml view file goes here
    }
}
```

### Folder Structure
- create a folder names exactly "Views" in your project folder
- inside the Views folder, create another folder based on your controller name.  For UserController.cs name the folder User
- create a .cshtml file to be a view
- a Shared folder will be created that will be used to look for views if the file is unable to find the correct view folder inside Views

### View();
```cs
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers;
public class HelloController : Controller
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
    [HttpGet]
    [Route("info")]
    public ViewResult Info()
    {
        // Same logic for serving a view applies
        // if we provide the exact view name
        return View("Info");
    }
    // You may also serve the same view twice from additional actions
    [HttpGet("elsewhere")]
    public ViewResult Elsewhere()
    {
        // This would be a case where we have to specify the file name
        return View("Index");
    }
}
```
---
## Razor View Engine
- razor allows us to swap back and forth between C# code and HTML using the @ symbol
```html
<!-- html/head tags removed for brevity -->
<body>
<!-- Notice how @ starts our C# section
 and we have wrapped all our logic in a code block -->
@{    
    List<string> StringList = new List<string> {"one", "two", "three", "four"};
    foreach(string word in StringList)
    {
        // We can render HTML from within C# code!
    	// We just have to remember to bring @ back if we want to render variables
        <p>@word</p>
    }
}
</body>
```
- use @{} to write a block of C# logic, such as loops and declaring variables
- to use a variable you only need to use a @ with the variable name after
```html
<!-- html/head tags removed for brevity -->
<body>
@{    
    List<string> StringList = new List<string> {"one", "two", "three", "four"};            
    foreach(string word in StringList)    
    {        
        <div>            
            <p>@word</p>  
    	    // Notice here we started a code block
    	    // But since an if statement already comes with {}
    	    // we are able to get away without wrapping the whole condition
            @if(word.Length < 4)            
            {                 
                <p>@word is a short word</p>            
            }       
        </div>    
    }
}
</body>
```
---
## Static Files
- static files refers to any CSS, images, or JavaScript you bring into the project to add visual or functional interest
### File Structure
- create a new folder named exactly "wwwroot" to contain these static files
- inside wwwroot, you can create folders for any static elements you need to use: css, images, etc.
- notice the ~ used in place of wwwroot
### Using Static files in your views
```html
<!DOCTYPE html>
<html>    
<head>        
    <meta charset='utf-8'>        
    <title>Index</title>        
    <!-- In this context '~' refers to the wwwroot folder  -->      
    <link rel="stylesheet" href="~/css/style.css"/>    
</head>    
<body>        
    <h1>Hello ASP.NET Mvc!</h1>
    <!-- Images use the same method -->
    <img src="~/images/myimage.jpg" alt="my cool image"/>
</body>
</html>
```
---
## ViewBag
- ViewBag can be used to pass information from the back-end (controller) to the front-end (view)
- It is a dictionary that exists only within the confines of the action we call it in.  It cannot send data across actions, but it can send data to the views
- to use ViewBag, we define keys to go in the ViewBag dictionary and assign values to them.
```cs
// Other code 
[HttpGet("")]
public IActionResult Index()
{    
    // Here we assign the value "Hello World!" to the key .Example    
    // Key names can be whatever you like    
    ViewBag.Example = "Hello World!";    
    return View();
}
```
```html
<!-- Inside our csHTML -->
<h1>@ViewBag.Example</h1>
```
---
## Redirecting
- uses RedirectResult instead of ViewResult and returns Redirect()
### Redirecting to a route
```cs
// Other code
[HttpGet("here")]
public ViewResult Here()
{
    // Make sure you have a cshtml file called Here with some text in it for this to work
    return View();
}
    
[HttpGet("redirect")]
public RedirectResult GoSomewhere()
{
    // Notice we do not need to specify localhost:5XXX, just what comes after
    // If we wanted to redirect to the front page, we would write ("/")
    return Redirect("/here");
}
```
### Redirecting to an Action Result
- redirecting to a route is helpful, but not the best way to handle redirects, as it relies on route names, which can be arbitrary and subject to change
- we can and should instead use a **RedirectToActionResult**, which will look for the name of an action (the method, like Index or GoSomewhere)
```cs
// Other code
[HttpGet("here/{name}")]
public ViewResult Here(string name)
{        
    return View();
}  
  
[HttpGet("redirect/{myName}")]
public RedirectToActionResult GoSomewhere(string myName)
{
    // In this case to pass a parameter we must make an anonymous object and pass a key/value
    // that matches the key to the expected parameter name on the other route
    return RedirectToAction("Here", new {name = myName});
}
```
---
## IActionResult
- IActionResult is a catch-all result.  It can be used for views, redirects, json, etc.
- In situations where you aren't exactly sure on what kind of return result you will get, use IActionResult
> **YourController.cs**
```cs
// Here is a standard ViewResult you are familiar with
[HttpGet("")]
public ViewResult Index()
{
    return View();
}
    
// And here is an IActionResult
[HttpGet("result/{favoriteResponse}")]
public IActionResult ItDepends(string favoriteResponse)
{
    if(favoriteResult == "Redirect")
    {
    	return RedirectToAction("Index");
    } else if (favoriteResponse == "Json") {
    	return Json(new {favoriteResponse = favoriteResponse});
    } else {
    	return View();
    }
}
```
- the problem with IActionResult is that it's not as performance efficient, so try to use it sparingly
---
## Forms
- forms should specify that they trigger a post request and where the request can be received
```html
<form action="process" method="post">
    <!-- the action=" " shows where the request can be received -->
    <input type="text" name="TextField"/>
    <input type="number" name="NumberField"/>
    <input type="submit" value="Submit"/>
</form>
```
- in our controller:
```cs
// remember to use [HttpPost]
[HttpPost("process")]
public IActionResult Process(string TextField, int NumberField)
{    
    // Do something with form input
    Console.WriteLine($"My text was: {TextField}");
    Console.WriteLine($"My number was: {NumberField}");
    // Then don't forget to return some kind of result!
}
```
- make sure that you match the name attribute in your form to the parameter names in your post method
---
