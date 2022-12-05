#pragma warning disable CS8618
namespace DojoSurvey.Models;
using System.ComponentModel.DataAnnotations;

public class Survey 
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3)]
    public string name {get;set;}

    public DateTime birthday {get;set;}
    
    public string location {get;set;}
    public string language {get;set;}
    [MinLength(5, ErrorMessage = "Must contain 5 or more characters")]
    public string? comments{get;set;}
}