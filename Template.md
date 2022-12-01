Program.cs

```c#
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

Controllers

```c#
// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here!
namespace YourNamespace.Controllers;
public class HelloController : Controller   // Remember inheritance?
{
    [HttpGet] // We will go over this in more detail on the next page
    [Route("")] // We will go over this in more detail on the next page
    public string Index()
    {
    	return "Hello World from HelloController!";
    }
}
```

```c#
using Microsoft.AspNetCore.Mvc;
namespace ProjectName.Controllers;
public class HelloController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "Hello from the index";
    }

    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("user/more")]
    public string User()
    {
        return "Hello user";
    }

    // Post request example
    // This will go to "localhost:5XXX/submission"
    [HttpPost]
    [Route("submission")]
    // Don't worry about what the form is doing for now. We'll get to those soon!
    public string FormSubmission(string formInput)
    {
    	// Logic for post request here
        return "I handled a request!"
    }
}

ROUTE PARAMETERS
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

Rendering Views
in your controller file

```c#
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

Razor syntax

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

<!--  -->

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
