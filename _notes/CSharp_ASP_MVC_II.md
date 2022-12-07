# ASP.NET Core MVC II
## MVC Templates
- We can now build a full MVC project automatically by changing the line that creates our project folder from a "web" project to "mvc"
```
dotnet new mvc --no-https -o ProjectName
```
- this command will create our project folder, including the wwwroot, Models, Views, and Controllers folders with some base files inside
---
### Generated Files
> _Layout
- the _Layout.cshtml file in our Shared views folder serves as a master HTML document.  This lets us only define a complete HTML document once and allows us to keep our other View files lean
- the RenderBody() section is where everything we want to display from our Views comes in
#### _Layout.cshtml
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Head content removed for brevity -->
</head>
<body>
    <header>
        <!-- Header content removed for brevity -->
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @RenderBody()
        </main>
    </div>
    <footer class="border-top footer text-muted">
        <div class="container">
            © 2022 - FirstMVC - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <!-- scripts removed for brevity -->
<body>
<html>
```
#### Index.cshtml
```html
<!-- This changes what you see in the Title (the tab name at the top of your browser) -->
@{
    ViewData["Title"] = "Home Page";
}
<!-- Everything below this line gets rendered where @RenderBody() is in _Layout -->
<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="<a href="https://docs.microsoft.com/aspnet/core">https://docs.microsoft.com/aspnet/core</a>">building Web apps with ASP.NET Core</a>.</p>
</div>
```
> ViewStart
- ViewStart is located outside of the Shared and Home folders and includes code that tells your project which layout to use when it renders any page.  By default, it is the one that the project created, but we can create additionals
- To do so, make a new cshtml file in shared that starts with _ and tell your View cshtml file to render that layout instead
```html
@{
    ViewData["Title"] = "Home Page";
    Layout = "_MyIndexLayout";
}
<div class="text-center">
    <h1 class="display-4">Welcome</h1>
</div>
```
---
## Models
### Building a Model
- models are classes that go inside the Models folder in our project
- Name your models as singular nouns (Friend, User, Pet) and capitalize the first letter
```cs
// Notice the use of the "Models" tag the same way we put "Controllers" in our Controller file
namespace YourNamespace.Models;
public class Friend    
{    
    // We must put {get;set;} after all our properties
    // This will give ASP.NET Core the permissions it needs to modify the values    
    public string FirstName {get;set;}        
    public string LastName {get;set;}        
    public string Location {get;set;}
    public int Age {get;set;}    
}
```
- You may notice that we're getting error messages now on the fields regarding being non-nullable properties.  We can solve this by telling the program to ignore the error at the top of the model file
```cs
#pragma warning disable CS8618
```
- OR, if we want to be able to store "null" for a value we can add a ? after the type.  This should only be done for fields where null is a reasonable response
```cs
public string? Location {get;set;}
```
- There is a third fix called the **null forgiving operator**, but it should ONLY be used when you know for certain that a non-null value will go into the property (i.e. there are validations that would catch it before null goes into the field)
```cs
public string FirstName {get;set;} = null!;
```
### View Models
- ViewModels help maintain strict typing in our views so we always know what we're working with, while being able to pass information to our HTML
- they allow for back-end validations, streamlining form setup
- ideally, we'll be using ViewBag as little as possible and ViewModels when able to
> Passing Information from our ViewModel to our View
```cs
 // all our other controller code
[HttpGet("")]
public IActionResult Index()
{
    int myNum = 12;
    // we create a ViewModel int here and then pass it into the View()
    return View(myNum);
    // we didn't specify a cshtml file here, but we could have used:
    // return View("Index", myNum);
}
```
- one important thing to note is that we can only pass **one** variable into the available slot, unlike ViewBag, which lets us pass as many as we want
> Rendering Data on our View
- At the top of our cshtml file, we need to add the following:
```cs
@model int
// replace int with whatever data type was passed into the file
// i.e. string, List<bool>, etc.
```
- then we can render the data:
```cs
@model int
@* Take note we use a capital "M" Model here, but a lowercase "m" model above *@
<h2>Here is my integer from ViewModel: @Model<h2>
```
> Passing down objects and collections of data
- Begin by creating a model
```cs
#pragma warning disable CS8618
namespace YourProjectName.Models;
public class User
{
    public string FirstName {get;set;}
    public string LastName {get;set;}
}
```
- Now in the controller, we can make an instance of our model
```cs
[HttpGet("user")]
public IActionResult AUser()
{
    User newUser = new User()
    {
        FirstName = "Nichole",
        LastName = "King"
    };
    return View(newUser);
}
```
- Now we can tell our cshtml file to expect a ViewModel of User
```cs
@model User
<h2>Here is a user<h2>
<h2>Name: @Model.FirstName @Model.LastName<h2>
```
- We can do the same thing with lists and dictionaries
```cs
[HttpGet("words")]
public IActionResult Words()
{
    List<string> names = new List<string>();
    names.Add("Nick");
    names.Add("Riley");
    names.Add("James");
    names.Add("Sara");
    return View(names);
}
```
```cs
@model List<string>
<h2>Here are some names!</h2>
@foreach(string name in Model){
    <p>@name</p>
}
```
### Model the class VS Model the ViewModel
- A ViewModel simply denotes that some sort of information has been passed along using the return statement.  It does not need to be ONLY a model from a class.
- Notice our examples earlier where we passed an int and a list of names.
---
## Models and Forms
- Models can simplify form submission by allowing us to take in just the form data as a whole, rather than each field individually
```cs
public class HogwartsStudent
{
    public string Name {get;set;}
    public string House {get;set;}
    public int CurrentYear {get;set;}
}
```
- Make the "name" attribute for each of the form inputs match their corresponding field from our class
```html
<form action="register" method="post">    
    <label>Your Name:</label>    
    <input type="text" name="Name">   <!-- updated -->  
    <label>House:</label>    
    <select name="House">  <!-- updated -->       
        <option value="Gryffindor">Gryffindor</option>        
        <option value="Ravenclaw">Ravenclaw</option>        
        <option value="Slytherin">Slytherin</option>        
        <option value="Hufflepuff">Hufflepuff</option>    
    </select>    
    <label>Year:</label>    
    <input type="number" name="CurrentYear">  <!-- updated -->   
    <input type="submit" value="Submit"/>
</form>
```
- now have the post request accept the Model object rather than each variable separately
```cs
[HttpPost("register")]
public IActionResult RegisterWizard(HogwartsStudent student) // updated
{    
    // process the form...
    // You can start by logging the data to the console
    // or using the debugger to inspect the HogwartsStudent instance!
} 
```
---
## Validations
### In the Model
- we need to setup some additional features.  **NOTE**: not necessary if you use the mvc project setup instead of the web project
```
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```
> Model Setup
- we will be adding validations using built-in attributes called **DataAnnotations**. which we need to include in our Model
```cs
using System.ComponentModel.DataAnnotations;
namespace YourNamespace.Models;   
public class User
{    
    // Class definition
}
```
- the DataAnnotations library includes many validations.  The most common ones are:
```
Required
Regular Expression() // takes a regex expression
MinLength(int)
MaxLength(int)
Range(a, b) // int or double, must match the field type
EmailAddress
Compare() // applied to one field and takes a string corrosponding to the other field and an error message
DataType() // takes a DataType object
```
> Applying Validations
- applying validations looks very similar to applying an HTTP verb or route
```cs
// Don't forget to disable the warnings!
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace YourNamespace.Models;
public class User
{    
    // Each property in a model gets its own set of DataAnnotations
    // Each annotation applies only to the property that is directly below it
    [Required]   
    // We can stack annotations to apply multiple requirements to one property
    // In this case, a Username is required but must also be at least 3 characters long 
    [MinLength(3)]    
    public string Username { get; set; }     
    // Notice how we must use [Required] again here to apply to the next property
    [Required]   
    // This will apply a standard Email format regex to this property 
    [EmailAddress]    
    public string Email { get; set; }     
    
    [Required]    
    // You will see what the [DataType] annotation does when we get over to making our form
    [DataType(DataType.Password)]    
    public string Password { get; set; } 
}
```
- the validations come with default error messages, but if you want to use custom error messages you can!
```cs
[Required(ErrorMessage="Name is required!")]  
[MinLength(3, ErrorMessage="Message must be at least 3 characters in length.")]
```
### Form Setup
> Creating the Form
- ASP tag helpers streamline the form process.  Below is the original form and then the form using asp-for
```html
<form action="user/create" method="post">
    <label for="Username">Username</label>
    <input type="text" name="Username">
    <label for="Email">Email</label>
    <input type="text" name="Email">
    <label for="Password">Password</label>
    <input type="password" name="Password">
    <input type="submit" value="Add User">
</form>
```
```html
@model User
<form action="user/create" method="post">    
    <label asp-for="Username"></label>
    <input asp-for="Username">    
    <label asp-for="Email"></label>
    <input asp-for="Email">    
    <label asp-for="Password"></label>
    <input asp-for="Password">    
    <input type="submit" value="Add User">
</form>
```
- in labels, asp-for takes the place of "for" and the label text between the brackets
- in the inputs, asp-for replaces "type" and "name", using the model to determine the type
> Adding Validations to the Form
- add span tags with "asp-validation-for"
```html
@model User
<form action="user/create" method="post">
    <label asp-for="Username"></label>
    <input asp-for="Username">
    @* Added line *@
    <span asp-validation-for="Username"></span>
    <label asp-for="Email"></label>
    <input asp-for="Email"> 
    @* Added line *@
    <span asp-validation-for="Email"></span>
    <label asp-for="Password"></label>
    <input asp-for="Password">
    @* Added line *@
    <span asp-validation-for="Password"></span>
    <input type="submit" value="Add User">
</form>
```
- instead of the form action="route", we can use asp-action to direct the form to a specific controller action, which is less ambiguous.  We also will specify the controller with asp-controller
```html
@model User
@* Notice how we changed action to asp-action and added asp-controller *@
<form asp-action="Create" asp-controller="Home" method="post">        
    <label asp-for="Username"></label>    
    <input asp-for="Username">
    <span asp-validation-for="Username"></span>
    <label asp-for="Email"></label>    
    <input asp-for="Email"> 
    <span asp-validation-for="Email"></span>
    <label asp-for="Password"></label>    
    <input asp-for="Password">  
    <span asp-validation-for="Password"></span>
    <input type="submit" value="Add User">
</form>
```
### Validations in the Controllers
> ModelState 
- first we must update our controller to use ModelState, so that the controller can compare the Model object passed through our post request to the class model
```cs
// We need this line to connect to our models
// It should already be at the top of your file, but double check anyway
using YourNamespace.Models; 
// Other routes
[HttpPost("user/create")]
public IActionResult Create(User user)
{    
    if(ModelState.IsValid)    
    {        
        // Do somethng! Maybe insert into a database or log data to the console  
        // Then we will redirect to a new page        
        return RedirectToAction("SomeAction");    
    }    
    else    
    {        
        // Oh no! We need to return a ViewResponse to preserve the ModelState and the errors it now contains!        
        return View("NewUser");    
    }
}
```
### Custom Validations
- built-in validations inherit from an abstract class called ValidationAttribute, allowing the framework to run all ValidationAttributes instead of all MinLengthAttributes, then all RangeAttributes, etc
- below is what the class looks like under the hood
```cs
public abstract class ValidationAttribute : Attribute
{    
    public virtual bool IsValid(object value);    
    protected virtual ValidationResult IsValid(object value, ValidationContext validationContext);
}
```
- we can extend this class to make our own ValidationAttribute
```cs
// Create a class that inherits from ValidationAttribute
public class NoZNamesAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (((string)value).ToLower()[0] == 'z')
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No names that start with Z allowed!");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}
```
- we can now apply this attribute class to our model based on the name we gave the class, excluding the word Attribute
```cs
public class User
{    
    [NoZNames]    
    public string FirstName {get;set;}
}
```
---
## Session
### Setting up Session
- Session holds persistent data in a cookie
- we must first add it to our projects Program.cs
```cs
// AddHttpContextAccessor gives our views direct access to session
// Add these two lines before calling the builder.Build() method
// They fit nicely right after AddControllerWithViews() 
builder.Services.AddHttpContextAccessor();  
builder.Services.AddSession();  

// add this line before calling the app.MapControllerRoute() method
// It fits nicely with other Use statements like app.UseStaticFiles();
app.UseSession();    
```
- in ASP.NET Core, session can only hold int and strings and must be specified at declaration
### GETting and SETting session
- in the controller:
> Getting and Setting strings
```cs
// To store a string in session we use ".SetString"
// The first string passed is the key and the second is the value we want to retrieve later
HttpContext.Session.SetString("UserName", "Samantha");
// To retrieve a string from session we use ".GetString"
string LocalVariable = HttpContext.Session.GetString("UserName");
```
- First, we SET a string by passing it a key and value
- Second, we GET our session and store it in a variable of the appropriate type
- Third, we use GetString followed by the key name
> Getting and Setting integers
```cs
// To store an int in session we use ".SetInt32"
HttpContext.Session.SetInt32("UserAge", 28);
// To retrieve an int from session we use ".GetInt32"
int? IntVariable = HttpContext.Session.GetInt32("UserAge");
```
- the ? is required, because if we make a call for a session that does not exist, we would get back a null value and int cannot hold a null value.
### Clearing Session
- running this command in the route will clear session:
```cs
HttpContext.Session.Clear();
```
### Accessing Session in Views
```cs
@Context.Session.GetString("KeyName")
```
- replace KeyName with the key you set up in your controller file

---