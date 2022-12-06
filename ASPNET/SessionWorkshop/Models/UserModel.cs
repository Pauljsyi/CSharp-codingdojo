#pragma warning disable CS8618
namespace SessionWorkshop.Models;
using System.ComponentModel.DataAnnotations;

public class User 
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3)]
    public string name {get;set;}
}