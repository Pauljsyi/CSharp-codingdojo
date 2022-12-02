#pragma warning disable CS8618
namespace DojoSurvey.Models;
using System.ComponentModel.DataAnnotations;

public class Survey
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3, ErrorMessage="Name must be at least 3 characters in length")]
    public string name {get;set;}
    public string location {get;set;}
    public string language {get;set;}
    public string comments{get;set;}
}